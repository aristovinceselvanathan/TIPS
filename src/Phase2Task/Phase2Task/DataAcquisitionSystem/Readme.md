# Data Acquisition System

## Project Overview

The Data Acquisition System that consists of the Compliance Module and Data Acquisition Module. The Compliance Module will get the input from the user to determine the lower and upper limit of the parameter that the Data Data Acquisition Module will operate properly.

## Project Architecture 

### Data Acquisition Module

- The Data Acquisition module consists of the Timer that will generate the values at the regular interval of the time.

- It will Initially  get the data from the json file to determine the range of the operation of the Data Acquisition module.

- It will also provide the refresh method to load the any changes in the json file without interrupting the program

- I have used the random function to generate the data for temperature and current by the timer class the event is triggers the event for every rate present in the json file.

### Compliance Module

- In the compliance module it will get the input from the user to set the values for the high and low values for the parameters to be checked.

- If DAQ generates the values that beyond the values of the Compliance module. It will throw the exception telling that it is beyond the limit.

### User Interface

- User Interface consists of the Start and End the Acquisition process of the DAQ.

- In order to run the DAQ user need to set the configure the  limits of the Compliance Module and Json Should contain the data for DAQ to generate the operation.

- Refresh Method that will refresh the DAQ Module when the user changes the jsonfile according to the changes in the json file.

- Exit is used to exit the console application.

## Implementation

- The Separate class for each module like CM and DAQ. This class will have the high and low value of the parameters.

- Timer is used to trigger the event that will update the value for each interval  it will generate the data along with the checking the data with the compliance module.

- The Data generating by the DAQ and checking the data by compliance module will run in the same thread.

- The user interface will run in the main thread. There user can manipulate the data.

- The Start and Stop in done by timer class.

## MileStones

- 1st Hour - Understand the needs and requirement of the application and the create the class that are required for the application.

- 2nd Hour - Basic functionality like the file operations and operations that need in the each class and timer implementation to make the DAQ Operations and Compliance module to check the data generated.

- 3rd Hour - Basic Functionality for the user interface to operate and get the input form the user. Testing part of the Class that have declared.

- 4th hour - Checking the basic user flow in the program. Satisfy the additional requirement if possible. The usability of the application is tested.