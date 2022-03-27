# ScreenBuilderWPF
This repo contains the samples that demonstrate the Screen Builder Application similar to visual studio toolbox and container developed in Windows Presentation Foundation in the .NET for Desktop. 
This is developed using .Net 5.
#Built with:
1. Visual Studio 2019(.Net 5)
2. Windows Presentation Foundation


#Requirement:

Layout of the designer

•	Use grid with two columns layout equally divided.
•	The First column should contain a list of controls (Refer Visual studio toolbox)
  o	Add textbox, label, checkbox, and a button control to the list.
•	The second column should be a container window to hold the controls added from the control list in a grid layout.
  o	The grid should be divided in 10:90:10 

Feature	

•	On click of any control from the list, the selected control should fly to the container column with animation. (Storyboard or any other approach)
  o	The height of the container should be fixed. 
  o	On reaching the screen limit after adding control a scroll should appear for the container.
•	Controls in the container should be enabled to change position vertically i.e., row only by dragging the controls.


NOTE: Use .NET 5 to create the APP and the git link to the code repo

This Project Contains 2 solutions one developed using WPF and other using MVVM
1. ScreenBuilder
2. ScreenBuiilderMVVM
