
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
$testLimit = 1

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
	Write-Output "		Retrieved: $totalRetrieved 	"

} while ($members.Count -eq $take -and $iteration -lt $testLimit)

Write-Output ""
Write-Output "		Total Retrieved: $totalRetrieved 	"
Write-Output ""

$allMembers | ForEach-Object { 

	$member = $_.value
	# Write-Output $member
	
	Write-Output "latest party id, name, color, is independent, memberFromId"
	Write-Output $member.latestParty.id
	Write-Output $member.latestParty.name
	Write-Output $member.latestParty.backgroundColour
	Write-Output $member.latestParty.isIndependentParty
	Write-Output $member.latestParty.membershipFromId
	Write-Output "main, spirtual ?"
	Write-Output $member.latestParty.isLordsMainParty
	Write-Output $member.latestParty.isLordsSpiritualParty

	Write-Output ""

	
	$putData = @{

	       	# LastName = $member.nameListAs.Split(',')[0].Trim()
		
	       	NameFullTitle = $member.nameFullTitle
	       	HouseId = $member.id
	       	LatestPartyId = $member.latestParty.id
	       	Gender = $member.gender

		ImageUrl = $member.thumbnailUrl

		MemberFrom = $member.latestHouseMembership.membershipFrom
		MembershipStartDate = $member.latestHouseMembership.membershipStartDate
		MembershipEndDate = $member.latestHouseMembership.membershipEndDate
		MembershipStatusIsActive = $member.latestHouseMembership.membershipStatus.statusIsActive
		MembershipEndReason = $member.latestHouseMembership.membershipEndReason
		
       	}	       
       	$jsonData = $putData | ConvertTo-Json

	Write-Output $jsonData

#       	try {
#		$response = Invoke-RestMethod -Uri $microserviceUrl -Method Put -Headers @{ 
#			"Content-Type" = "application/json" } -Body $jsonData
#		Write-Output "		MicroService Saved : $response"
#       	}
#	catch {
#		Write-Output ""
#		Write-Output "		Error: $_"
#		Write-Output ""
#	}

}

Write-Output ""
Write-Output "		___		"
Write-Output ""

#	$_.value | Select-Object id, 
#  nameListAs, 
#  latestParty.name, 
#  gender, 
#  latestHouseMembership.membershipFrom,
#  latestHouseMembership.membershipStartDate,
#  latestHouseMembership.membershipEndDate,
#  latestHouseMembership.membershipEndReason,
#  latestHouseMembership.membershipEndReasonNotes,
#  latestHouseMembership.membershipStatus.statusIsActive,
#  latestHouseMembership.membershipStatus.statusDescription
  
#} 
