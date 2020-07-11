# SimpleScan
Simple app that pings a website to check its status.  Checks to see if the website is down and notifies the user.  Application created in mind to assist teachers, professors, lecturers, and researchers amidst the shift toward online learning as a result of the corona virus pandemic.

Contains a GUI where a user can add a class/lecture that groups links together.  The user can also click the scan button to ping the websites and check their status.


###### How to use this app ######

navigate to your install location and find the SimpleScan folder.  After opening the folder run the 'LinkLookout.exe' file.  This will bring up the User Interface.  Click on "Add Links to Monitor" to take you to the link management panel.  

###### Adding Link ######

You must add a class/lecture name on the left hand side before adding links to monitor.  On the left hand side, type in a class name and click on the 'Add Class' button.  You can add as many as you would like.  To add links to scan, first click on a class that the weblink will belong to.  Then, on the right hand side, type in a weblink to monitor in the following format "http(s)://www.websitename.com" and click on the 'Add Link' button.  if you do not include the http(s) prefix, the scan will not work.  

For example: https://www.facebook.com or http://www.nyu.edu/ (**ALWAYS BE WARY OF HTTP LINKS, they are insecure and contain no encrpytion)

###### Delete Links ######

To delete a web-link, first select the class it belongs to by clicking on the class name on the left hand side.  Then select a link on the right hand side and click on the 'Delete' button.  Afterwards, a popup will come up asking if you want to delete this link.  Click 'Yes' to delete the link and click 'No' to cancel deletion.  To delete a class, select the class you wish to delete and click the 'Delete' button.  Afterwards, a popup will come up asking if you want to delete this class.  Click 'Yes' to delete the class and click 'No' to cancel deletion.  Note that if you delete the class, all of its associated links will also be deleted


###### Scanning Website ######

Click the "Scan" button in the center of the panel.  If there are classes and links to scan, then the application will begin to scan weblinks.  If there are no classes or links to scan, the application will notify the user to add classes and linnks to scan.

After clicking the "Scan" button, the application will begin pinging websites for their status.  If a website link was not formatted correctly, or if it does not exist, the application will alert a message to the user.  Note that it may appear that nothing is happening, but the application is running a scan.  Please wait a moment for it to complete.  The scan will display alert messages once it is complete, either "No bad links" if the websites are healthy, or a list of weblinks that failed the scan and the class that they are grouped by.
