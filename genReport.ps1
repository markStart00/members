
Write-Output ""
Write-Output "		Generating ...		"
Write-Output ""

$microserviceUrl = "https://localhost:7106/all-members"
$response = Invoke-RestMethod -Uri $microserviceUrl -Method Get

$memberData = @()

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
		MemberFrom = $member.membershipFrom
		ImageUrl = $member.imageUrl
       	
	}

	$memberData += $customObject

}

$htmlTable = $memberData | ConvertTo-Html -Property Id, HouseOfLordsId, NameFullTitle, Gender, PartyId, MembershipStatusIsActive, MembershipStartDate, MembershipEndDate, MembershipEndReason, MemberFrom, ImageUrl -Fragment

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


