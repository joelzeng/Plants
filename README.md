# Plants

The Project has been done with .Net Core as my local workstation is MacOSX.
Front-End was developed with VueJS and custom assets were made by myself.

Sample: 
![Alt text](./sample.png?raw=true "Sample")

# Assumptions
In order to determine when a plant needs to be watered, i opted to check for its last time watered. If it is > 1 hour. Then it must be watered. Everything else follows specs

# Launch Instructions

- The backend has to be built and ran. Currently configured on port **5001**. On any visual studios (I used Visual Studio Mac)
- For the front end, it can be ran through the terminal. The front end is located inside the [rootProjectFolder]/app
and run `npm run start` or `npm run dev`. Currently configured on port **8080**

* Note: Db is implemented with **EntityFrameworkCore.InMemory**.
  The application always starts with a hard coded state that gets loaded to memory. As long as the backend keeps running the states should be updated.

# Common troubleshoot
Install node packages `npm install`
Restore Nuget Packages if backend fails.

You might also need .Net Core SDK
