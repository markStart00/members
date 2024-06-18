
Write-Output ""
Write-Output "		Generating ...		"
Write-Output ""

$microserviceUrl = "https://localhost:7106/all-members"
$response = Invoke-RestMethod -Uri $microserviceUrl -Method Get

$memberData = @()

foreach ($member in $response) {

	$customObject = [PSCustomObject] @{
		id = $member.id
		lastname = $member.lastName
	}

	$memberData += $customObject

}

$htmlTable = $memberData | ConvertTo-Html -Property id, lastname -Fragment
$totalCount = $memberData.Count

$htmlFile = @"
	<!DOCTYPE html>
	<html>
	<head>
		<title>Report</title>
	</head>
	<body>
		<h2>Report</h2>
		<p>Total Members: $totalCount</p>
		$htmlTable
	</body>
	</html>
"@


$htmlFile | Out-File -FilePath "./report.html"


