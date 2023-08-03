# Dont Starve Together Dedicater Server Runner

### Hello everyone, this is a simple application to manage a dedicated server for Don't Starve Together.

---

### Disclaimer: 

```This application is not affiliated with Klei Entertainment Inc. in any way.```

```This is a fan-made project. I like to host my own DST servers and I wanted to make it easier for me to manage it.```

```Because I don't have any certificate, when running the app Windows will probably block it. If you don't trust me, you can check the code yourself.```

---

### How to use:

#### You have 3 buttons:
- One to start the server;
- One to stop the server;
- One update the status of the server in the application;

---

When opening the application it will create a folder in your `%appdata%` folder called `DontStarveTogetherServerRunnerConfig` with a `config.txt` file with the path of your `StartDSTServer.bat`.

---

You can select where your own StartDSTServer.bat is located by clicking on the lower bar (by default is in the Documents - Klei - DoNotStarveTogether folder) and it will update the config file inside the folder mentioned above.

---

When starting the server, based on what's in the config, it will run the `StartDSTServer.bat` and it will update the status of the server in the application.

---

When stopping the server, it will write 
```bash
c_shutdown()
```
in all the processes that have in their name, either `dontstarve_dedicated_server_nullrenderer_x64` or `dontstarve_dedicated_server_nullrenderer` so all the progress is saved and it will update the status of the server in the application.

---

This is what the application looks like in v1.0.0

![image](https://github.com/ricardosantosduarte/dont-starve-together-server-runner/assets/47739966/de07e27b-05b6-4db2-b838-defc17f08d47)

