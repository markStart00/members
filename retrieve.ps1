
# https://members-api.parliament.uk/api/Members/Search?skip=4808&take=20	last	4808
#  both main and spirutal lord 4741 ?

Write-Output ""
Write-Output "		Retrieving ...		"
Write-Output ""

$houseOfUrl = "https://members-api.parliament.uk/api/Members/Search"
$microserviceUrl = "https://localhost:7106/add-member" 

$allMembers = @()
$skip = 0
$take = 20
$totalRetrieved = 0
$iteration = 0
$limit = 1

do {
	$url = $houseOfUrl + "?skip=" + $skip + "&take=" + $take
	Write-Output "		Fetching: $url 	"
	$response = Invoke-RestMethod -Uri $url -Method Get
	$members = $response.items

	if ($members.Count -eq 0) {
		break
	}

	$allMembers += $members
	$totalRetrieved += $members.Count
	$skip += $take
	$iteration += 1

} while ($members.Count -gt 0 -and $iteration -lt $limit)

Write-Output ""
Write-Output "		Total Retrieved: $totalRetrieved 	"
Write-Output "		Total Iterations: $iteration"
Write-Output ""
Write-Output "		Saving ...		"
Write-Output ""

$allMembers | ForEach-Object { 

	$member = $_.value
	
	$putData = @{
	       	HouseOfLordsId = $member.id
	       	NameFullTitle = $member.nameFullTitle
	       	Gender = $member.gender
	       	PartyId = $member.latestParty.id
		MembershipStatusIsActive = $member.latestHouseMembership.membershipStatus.statusIsActive
		MembershipStartDate = $member.latestHouseMembership.membershipStartDate
		MembershipEndDate = $member.latestHouseMembership.membershipEndDate
		MembershipEndReason = $member.latestHouseMembership.membershipEndReason
		MemberFrom = $member.latestHouseMembership.membershipFrom
		ImageUrl = $member.thumbnailUrl
       	}	       

       	$jsonData = $putData | ConvertTo-Json

       	try {
		$response = Invoke-RestMethod -Uri $microserviceUrl -Method Put -Headers @{ 
			"Content-Type" = "application/json" } -Body $jsonData
		$responseId = $response.id;
		$responseName = $response.nameFullTitle;
		Write-Output "		MicroService Saved Member: $responseId, 	$responseName	"
       	}
	catch {
		Write-Output "		$_	"
	       	Write-Output "		$member"
		Write-Output ""

	}

}

Write-Output ""
Write-Output "		- - Program Complete - -	"
Write-Output ""

