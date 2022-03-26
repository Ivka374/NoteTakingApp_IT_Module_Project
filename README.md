# StaveN - EN
## About
### Structure
The project uses the Windows Presentation Foundation(WPF). Its structure is based off of the MVVM model.
### Uses
The project serves as a simple application, that allows the user to store and edit notes as they desire. 
Those notes can be styled accordingly with the modern design of the app. 
The app has some groundwork for also allowing the user to add musical scores to their notes. 
This feature, though, still remains in development.
### Role assignment
  Front-end by Iva Bondzheva,  
  Business logic by Atila Sarachoglu,  
  Data layer by Vasil Krastenov.
### Libraries and frameworks
- Caliburn.Micro (by Nigel Sampson, Rob Eisenberg, Thomas Ibel, Marco Amendola, Chin Bae, Ryan Cromwell, Matt Hidinger, Ken Tucker)
- Calibur.Micro.Core (by the creators of Caliburn.Micro)
- EntityFramework (by Microsoft)
- MySql.Data (by Oracle)
- Newtonsoft.Json (by James Newton-King)
- Manufaktura.Controls (by Jacek Salamon)
- Manufaktura.Controls.Desktop (by Jacek Salamon)
- Manufaktura.Controls.WPF (by Jacek Salamon)
- Manufaktura.Core (by Jacek Salamon)
- Manufaktura.Music (by Jacek Salamon)
### Tools
- Visual Studio 2019
- github.com and Git Bash
- Pichion
### Difficulty level
The libraryies enabling the storing and display of mmusical scores and symbols have little to no documentation online and practically no useful information readily available on them. That has lead to postponng said functionality until later versions despite the time and effort already spent on it.  
Another issue that arose was the availability of the database during testing on different machines. This has lead to many hiccups in the production of this app and has been a priorty due to the vital role it plays.  
Last, but not least comes the challenge of using WPF itself. As somebody with a slight amount of experience using JavaFX, which would translate into .xml files, the front-end developer decided to explore this form of solution. That proved to be far more challenging than expected, however, the realization had been reach far too late into development and has certainly been a burden throughout the process.  
Regardless, through the joint effort and collaboration of the team, a working and cohesive version of the application has been completed.
### Programing languages
- C#
- MySQL
- XAML
## Source code
### Basic functionality
The frame surrounding the contents of whatever selection has been made contains:
- A logo
- A selection menu right under the logo, allowing the user to sort through notes based on specific properties
- A button for creating a new note
- A selection of custom buttons in the upper-right-hand corener, replacing the standard buttons for minimization, maximization and closing a window
### Home page
The home page displays all the tags stored inside the database and allows the user to select and open them in order to edit each individual note.
### Favourites page
Has the same functionality as the home page accept that it only shows the tags that have been marked as favourite
### Tag view page
Again, similar to the home page, but its title changes depending on the selected tag and the contents correspond to notes that have that same tag
### Note view window
This window is opened either when a new tag is being created, in which case its contents are black and the background is set to the default,
or when a note is selected and opened, in which case, the window is populated with the date from said note.  
The background also changes dynamically. Tags can also be adjusted and altered, as well as created.
### Warning winow
In oreder to exit from the note view window the user has to either delete the note through the settings or press 'Escape'
When the button is pressed this window appears, askin whether the user wants to save any changes made to the note.
It offers the option to save the file and exit it, simply exit without saving or cancel out of the operation and contionue editing the note.
### Everything else
All the other classes and structures are meant to enable the previously mentioned classes to perform their job.
## Future development
As previously mentioned, the goal from the start was to enable the user to add musical scores to their notes. Due to various restrictions that was not possible for theis version. The goal for the future is to utilise the groundwork that has been laid for that functionality.
## (Prmary) Sources
- Google
- Stack Overflow
- MSDN and other derivatives
- various othe developer forums
