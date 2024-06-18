
#	addd0a14-f489-4c42-9660-691b1601ffcc

Write-host ""
Write-Host "  This program guesses v4 UUID's. The probability is 2^128 ... "
Write-host ""
$number = Read-Host -Prompt "  enter a UUID: "
Write-host ""
$validUUIDFormat = '^[0-9a-fA-F]{8}\b-[0-9a-fA-F]{4}\b-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$'
$run = ($number -match $validUUIDFormat)
	$guesses = 0
if ($run) {
		$array = @()
		$array += 97..122 | ForEach-Object { [char]$_ }
		$array += 65..90 | ForEach-Object { [char]$_ }
		$array += 48..57 | ForEach-Object { [char]$_ }
		$specialCharacters = "!-@~{}[];:()*&^%$£"
		$array += $specialCharacters.ToCharArray()
		$inputUuidArray = $number.ToCharArray()
		$blankArray = New-Object char[] $inputUuidArray.Length
		for ($i = 0; $i -lt $inputUuidArray.Length; $i++) {
			$blankArray[$i] = ' '
		}
		$displayArray = New-Object char[] $inputUuidArray.Length
		for ($i = 0; $i -lt $inputUuidArray.Length; $i++) {
			$displayArray[$i] = ' '
		}
		$search = $true
		while ($search) {
			Start-Sleep -Milliseconds 25
			for ($i = 0; $i -lt $inputUuidArray.Length; $i++) {
				$randomNumber = Get-Random -Minimum 0 -Maximum $array.Length
					if ( [int]$inputUuidArray[$i] -eq [int]$array[$randomNumber] ) {
						$blankArray[$i] = $array[$randomNumber]
						$displayArray[$i] = $array[$randomNumber]
					}
			}
			for ($i = 0; $i -lt $inputUuidArray.Length; $i++) {
				if ( $displayArray[$i] -eq $inputUuidArray[$i]  ) {
					continue;
				}
				# $randomNumber = Get-Random -Minimum 0 -Maximum 0x10000
				# $displayArray[$i] = [char]$randomNumber
				# $randomNumber = Get-Random -Minimum 0 -Maximum $array.Length
				# $displayArray[$i] = $array[$randomNumber]
				$displayArray[$i] = ' '
			}
			$guessUuidString = -join $blankArray
			$displayString = -join $displayArray
			Write-Host "        " $displayString
			#Write-Host "        " $guessUuidString
			$guesses ++
				if ( $guessUuidString -eq $number ) {
					Write-Host ""
					for ($i = 0; $i -lt 4; $i ++) {
						Start-Sleep -Milliseconds 25
						Write-Host "        " $displayString
					}
					$search = $false
					Write-Host ""
					Write-Host "  uuid found !"
					$logBase2 = [Math]::Log($guesses, 2)
					Write-Host "  total number of guesses: " $guesses
					Write-Host "  in powers of 2 : 2^"$logBase2
					Write-Host "  probability of guessing 2^128 ... "
					for ($i = 0; $i -lt 4; $i ++) {
						Write-Host ""
						Write-Host ""
						Start-Sleep -Seconds 1
					}
				}
		}	
	}
else {
	Write-Host "  invalid v4 uuid - exiting program"
		Write-host ""
}
