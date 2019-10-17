# Plants

The Project has been dont with .Net Core as my local workstation is MacOSX.
Front-End is developed with VueJS and custom assets made by myself.

Sample: 
![Alt text](./sample.png?raw=true "Sample")

# Assumptions
In order to determine when a plant needs to be watered, i opted to check for its last time watered. If it is > 1 hour. Then it must be watered. Everything else follows specs

# Launch Instructions

- The backend has to be ran. Currently configured on port **5001**. On any visual studios (I used Visual Studio Mac)
- For the front end, it can be ran through the terminal. The front end is located inside the [rootProjectFolder]/app
and run `npm run start` or `npm run dev`. Currently configured on port **8080**

* Note: State management is implemented with **EntityFrameworkCore.InMemory** Package.
  The application always starts with a hard coded state that gets loaded to memory. As long as the backend keeps running the states should be updated.

# Common troubleshoot
Install node packages `npm install`
