**<h1 align = "center"> The Art**


<h1 align="center">
  <img width="900" height="450" src="https://coding-assets.s3-us-west-2.amazonaws.com/hero_images/TheArt.Solution.jpg">
</h1>

**<h1 align="center">"you have dollars, we have art"**


**<h4 align = "center">
  <a href="#✅requirements">Requirements</a> •
  <a href="#💻setup">Setup</a> •
  <a href="#🔧protecting-your-data">Protecting Data<a> •
  <a href="#📫questions-and-concerns">Q's & C's</a> •
  <a href="#🔧technologies-used">Technologies</a> •
  <a href="#🐛bugs">Bugs</a> •  
  <a href="#❤️contributors">Contributors</a> •
  <a href="#📘license">License</a>**

<br>
<h2 align = "center">
</h1>

**ABOUT**

we've got artists, we've got art. come look at this stuff


## **✅REQUIREMENTS**

* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)


## **💻SETUP**

* _Install and configure MySQL_
  1. _This program utilizes MySQL Community Server version 8.0.15 and requires [this to be pre-installed](https://dev.mysql.com/downloads/file/?id=484914). Click the link at the bottom that reads "No thanks, just start my download"_
  2. _Use Legacy Password Encryption and set password to "epicodus"_
  3. _Click "Finish_

copy this url to clone this project to your local system:
```html
https://github.com/tmemmerson/TheArt.Solution.git
```

<br>

Once copied, select "Clone Repository" from within VSCode & paste the copied link as shown in the image below.

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/clone-github2.gif "Cloning from Github within VSCode")

<br>

* _Install the MySQL database_
  1. _Open a new terminal in your text editor (Ctrl+\` in V.S. Code) and run command `> echo 'export PATH="$PATH:/usr/local/mysql/bin"' >> ~/.zprofile`_
  2. _Enter the command `> source ~/.zprofile` to confirm MsSQL has been installed_
  3. _Connect to MySQL by running the command `> mysql -uroot -pepicodus`_
  4. _Install the necessary MySQL database by copying the code block below and entering it into your terminal_
  5. _Once the following code block has been entered you will close MySQL by running the command `> exit`_

```
    DROP DATABASE IF EXISTS `TheArt`;
    CREATE DATABASE `TheArt` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
    USE TheArt;
    CREATE TABLE `Artists` (
    `ArtistId` int(11) NOT NULL AUTO_INCREMENT,
    `ArtistName` longtext,
    `DateOfBirth` datetime(6) NOT NULL,
    `DateOfDeath` datetime(6) NOT NULL,
    PRIMARY KEY (`ArtistId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
    CREATE TABLE `Movements` (
    `MovementId` int(11) NOT NULL AUTO_INCREMENT,
    `MovementName` longtext,
    `MovementDescription` longtext,
    `MovementStart` datetime(6) NOT NULL,
    `MovementEnd` datetime(6) NOT NULL,
    PRIMARY KEY (`MovementId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
    CREATE TABLE `ArtistMovement` (
    `ArtistMovementId` int(11) NOT NULL AUTO_INCREMENT,
    `ArtistId` int(11) NOT NULL,
    `MovementId` int(11) NOT NULL,
    PRIMARY KEY (`ArtistMovementId`),
    KEY `IX_ArtistMovement_ArtistId` (`ArtistId`),
    KEY `IX_ArtistMovement_MovementId` (`MovementId`),
    CONSTRAINT `FK_ArtistMovement_Artists_ArtistId` FOREIGN KEY (`ArtistId`) REFERENCES `artists` (`ArtistId`) ON DELETE CASCADE,
    CONSTRAINT `FK_ArtistMovement_Movements_MovementId` FOREIGN KEY (`MovementId`) REFERENCES `movements` (`MovementId`) ON DELETE CASCADE
    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
    CREATE TABLE `Pieces` (
    `PieceId` int(11) NOT NULL AUTO_INCREMENT,
    `PieceName` longtext,
    `PieceDate` datetime(6) NOT NULL,
    `PieceImage` longblob,
    `ArtistId` int(11) NOT NULL,
    PRIMARY KEY (`PieceId`),
    KEY `IX_Pieces_ArtistId` (`ArtistId`),
    CONSTRAINT `FK_Pieces_Artists_ArtistId` FOREIGN KEY (`ArtistId`) REFERENCES `artists` (`ArtistId`) ON DELETE CASCADE
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```

<br>

* _Run the application_
  1. _In the terminal, navigate to the project directory by running the command `> cd TheArt`_
  2. _Now that we are in the TheArt directory you will run the command `> dotnet restore`_
  3. _Once the "obj" folder has initialized you will run the command `> dotnet run`_
  4. _Go to http://localhost:5000/ in your preferred browser to use the application_

![cloning](https://coding-assets.s3-us-west-2.amazonaws.com/img/dotnet-readme.gif "How to clone repo")


## **🔧PROTECTING YOUR DATA**

#### **Step 1: From within VSCode in the root project directory, we will create a .gitignore file**

# For ![l-top](https://github.com/ryanoasis/nerd-fonts/wiki/screenshots/v1.0.x/mac-pass-sm.png)
```js 
touch .gitignore 
```

# For ![l-top](https://github.com/ryanoasis/nerd-fonts/wiki/screenshots/v1.0.x/windows-pass-sm.png)

```js 
ni .gitignore 
```

#### Step 2: commit that .gitignore file (this prevents your sensitive information from being shown to others). **⚠️DO NOT PROCEED UNTIL YOU DO!⚠️**

![setup](https://coding-assets.s3-us-west-2.amazonaws.com/img/entity-readme-image.png "Set up instructions")

#### Step 3: **To commit your .gitignore file enter the following commands**

```js
git add .gitignore
```
```js
git commit -m "protect data"
```

#### Step 4: **Then, you need to update your username and password in the appsettings.json file.**

_by default these are set to user:root and an empty password. if you are unsure, refer to the settings for your MySqlWorkbench._

![appsettings](https://coding-assets.s3-us-west-2.amazonaws.com/img/app-settings.png)

<br>

## **📫QUESTIONS AND CONCERNS**

_Questions, comments and concerns can be directed to the author [Tristan Emmerson](tristan@stickerslug.com)_

<br>

## **🔧Technologies Used**

_**Written in:** [Visual Studio Code](https://code.visualstudio.com/)_

_**Image work:** [Adobe Photoshop](https://www.adobe.com/products/photoshop.html/)_

_**Database Mgmt:** [MySql Workbench](https://www.mysql.com/products/workbench/)_

<br>


## **🐛Known Bugs**

_**None as of:** 8/6/2020_

<br>


## **❤️Contributors**


| [<img src="https://coding-assets.s3-us-west-2.amazonaws.com/linked-in-images/noel-kirkland.jpg" width="160px;"/><br /><sub><b>Noel Kirkland</b></sub>](https://www.linkedin.com/in/noel-kirkland/)<br />        | [<img src="https://coding-assets.s3-us-west-2.amazonaws.com/linked-in-images/allison-sadin.jpg" width="160px;"/><br /><sub><b>Allison Sadin</b></sub>](https://www.linkedin.com/in/allison-sadin-pdx/)<br /> | [<img src="https://coding-assets.s3-us-west-2.amazonaws.com/img/tristan_emmerson.jpg" width="160px;"/><br /><sub><b>Tristan Emmerson</b></sub>](https://www.linkedin.com/in/tristan-emmerson/)<br /> |
| :-----------------------------------------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------: |

<br>

## **📘License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2020 **_Tristan Emmerson, Stickerslug Inc._**

