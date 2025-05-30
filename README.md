MultiTenantBookingAPI
1.	Import Database:
Run Following Commands:
Add-Migration ‘Migration-Name’
Update Database

2.	Run the Application.
3.	Open postman.
   
4.	Browse the URL:
https://localhost:44328/api/bookings
In the Header Section, Pass the Key-Pair value as:
X-Tenant-ID: gym or localhost or pool
Pass Data in the Body Section as JSON as shown below:
{
  "FacilityID": 1,
  "Date": "2025-05-30T09:48:48.2703746+05:30",
  "StartTime": "03:00:00.1234567",
  "EndTime": "04:00:00.1234567",
  "UserName": "Nick",
  "UserEmail": "Nick@gmail.com",
  "isEnableNotifications": true
•	If MaxBookingHours is less than the Time period between Start and End Time, we get an error Message as:
 {
   "Message": "Booking exceeds maximum allowed hours."
 }
•	
}
•	Output: 
{
    "success": true
}

5.	Browse the URL:
https://localhost:44328/api/bookings/confirm
In the Header Section, Pass the Key-Pair value as:
X-Tenant-ID: gym or localhost or pool
Pass Data in the Body Section as JSON as shown below:

{
  "Email": "rahul@gmail.com"
}

•	Output:
"Confirmation email sent."

•	If “EnableNotifications” is set to false, we get the Error message as:
"Notifications are disabled for this tenant."
"Notifications are disabled for this tenant."
