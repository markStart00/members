
Write-Output ""
Write-Output ""
Write-Output "		Generating ...		"
Write-Output ""

$microserviceUrl = "https://localhost:7106/current-members"
$response = Invoke-RestMethod -Uri $microserviceUrl -Method Get

$iteration = 0
$memberData = @()
$htmlImageSelection = ""
$htmlColours = ""
$sampleSize = 25
#$sampleSize =
$maleCount = 0
$femaleCount = 0
$imageCount = 0

foreach ($member in $response) {

	$customObject = [PSCustomObject] @{

		Id = $member.id

	       	HouseOfLordsId = $member.houseOfLordsId
	       	NameFullTitle = $member.nameFullTitle
	       	Gender = $member.gender
	       	PartyId = $member.partyId
		MembershipStatusIsActive = $member.membershipStatusIsActive
		MembershipStartDate = $member.membershipStartDate
		MembershipEndDate = $member.membershipEndDate
		MembershipEndReason = $member.membershipEndReason
		MemberFrom = $member.memberFrom
		ImageUrl = $member.imageUrl
		PartyName = $member.party.name
		PartyColour = $member.party.colour
       	
	}

	if ($member.gender -eq 'm') {
		$maleCount ++
	}

	if ($member.gender -eq 'f') {
		$femaleCount ++
	}

	if ($iteration % $sampleSize -eq 0) {

		$imageUrl = $member.imageUrl

		if ($imageCount -eq 7) {
			$imageUrl = "./mrBurns.png"
		}

		if ($imageCount -eq 20) {
			$imageUrl = "./darth.png"
		}

		$htmlImageSelection += "<img src='$imageUrl' class='portrait' style=' 
			width:100px; 
			height=100px; 
			display:inline-block; 
			margin: 5px; ' />"

		$imageCount ++
	}

	if($member.party.colour) {
		$colour = $member.party.colour
		$htmlColours += "<div style=' 
			width:10px; 
			height:10px; 
			background-color: #$colour; 
			border: 1px solid white; 
			margin: 0px; 
			display: inline-block; '> </div>"
	}

	$memberData += $customObject
	$iteration ++

}


$totalMembers = $memberData.Count
$totalMembers = $totalMembers
$malePercent = [math]::round(( $maleCount / $totalMembers ) * 100)
$femalePercent = [math]::round(( $femaleCount / $totalMembers ) * 100)

$htmlSummaryTable = @"
<table>
	<tr><td>Total Members</td><td>$totalMembers</td></tr>
	<tr><td>Female</td><td>$femaleCount</td><td>$femalePercent %</td></tr>
	<tr><td>Male</td><td>$maleCount</td><td>$malePercent %</td></tr>
</table>
"@

$htmlMembersTable = $memberData | ConvertTo-Html -Property HouseOfLordsId, NameFullTitle, Gender, MembershipStartDate, MemberFrom, ImageUrl, PartyName, PartyColour -Fragment

$htmlFile = @"
<!DOCTYPE html>
<html>
	<head>
		<title>Report</title>
		<style>
			* {
				padding: 5px;
				margin: 5px;
			}
			.images {
				display: flex; 
				flex-wrap: wrap;
			}
			.portrait{
			}
		</style>
	</head>
	<body>
		<h2>Report</h2>
		$htmlSummaryTable
		<div class="images">
			$htmlImageSelection
		</div>

		<div class="images">
			$htmlColours
		</div>

		$htmlMembersTable
	</body>
</html>
"@

$filePath = "./report.html"

$htmlFile | Out-File -FilePath $filePath


Write-Output ""
Write-Output "		Report Saved: $filePath		"
Write-Output ""
Write-Output ""
Write-Output ""




