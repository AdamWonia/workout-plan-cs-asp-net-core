# Workout Plan - ASP .NET Core Web Application

## Description 

This repository contains a Workout Plan project made in C# using the ASP .NET Core Framework. This project was made using ASP .NET Core Web Application and the MVC (Model-View-Controller) template.

The user can view a list of exercises for each body part i.e. back, chest, hands, legs and stomach. On the home page there are tiles with the names of the body parts. After clicking on one of them, the user is redirected to the list of exercises. On this page, he can add a new exercise, see the details of a particular exercise, edit and delete selected ones. 

To add, edit and delete a particular exercise, the user must be logged in. When the user is not logged in, only the details options are visible on the exercise page. The remaining options are hidden until the user logs in. 

The user has also the possibility to register a new account. This requires an e-mail address and a password, which must comply with the given requirements.  

## MVC

The project uses the MVC architecture pattern. This means that the application is divided into three independent components:

- Model - responsible for data management
- View - front-end of the application
- Controller - the link between the View and the Model, responsible for retrieving, modifying and sharing data with the user.

The MVC pattern allows to separate the backend from the frontend of the application. It is also easier to make changes to each component without having to make changes to the other components.

The project contains five main models, which are:

- BackExercises
- ChestExercises
- HandsExercises
- LegsExercises
- StomachExercises

They contain all data describing each exercise. Models are linked to corresponding controllers for their modification. Each model has a corresponding view (Views) that allows the user to create, edit, delete and view the details of each model.

## Launch

To launch the project you should open the **MyProject.sln** file using Visual Studio. Then click the **IIS Express** button to start the localhost server. Once started, the home page should appear.
