# MacroRePlayer ⌨️🖱️

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![GitHub stars](https://img.shields.io/github/stars/greeeen013/MacroRePlayer)](https://github.com/greeeen013/MacroRePlayer/stargazers)

**MacroRePlayer** is an application designed for **recording**, **editing**, and **replaying** mouse and keyboard events. The main goal is to simplify the automation of repetitive tasks on a computer without the need to write custom scripts. The project is designed to provide a user-friendly interface with **maximum control** over recorded events, and will eventually allow additional advanced features like custom loops, infinite replay, or adjustable speeds.

---

## Table of Contents
1. [Key Features](#key-features-✨)
2. [Installation](#installation-🛠️)
3. [Requirements](#Requirements-🎯)
4. [Getting Started](#getting-started-🚀)
5. [Detailed Use](#Detailed-Use-📖)
   - [Recording](#Recording)
   - [Editing](#Editing)
   - [Replaying](#(Re)Playing)
6. [Configuration (coming soon)](#Configuration-⚙️-(TODO))
7. [Planned Features (TODO)](#Planned-Features-🗺️-(TODO))
8. [Contributing](#contributing)
9. [License](#license)

---

## Key Features ✨

- **Macro Recording** of mouse events (clicks, release) and keyboard events (press, release).
- **Advanced Editor** for modifying recorded macro events:
  - Changing the order of events.
  - Copying, pasting, and deleting events.
  - Inserting custom delays between events.
  - Adding custom loops (TODO).
- **(Re)Play**:
  - Replay actions with few millisecond accuracy 
  - The ability to set a custom **keybind** to start or stop playback.
  - Select a replay mode:
    - **One-time**  
    - **Repeat X times** (TODO)
    - **Infinite** (TODO)
  - Adjust the **playback speed** from **0.25×** to **10×** (TODO).
- **User-friendly interface** – easy to understand for users with no prior macro experience and many tool tips.
- **Advanced configuration options** for any future (TODO) additions.

---

## Installation 🛠️

- **Clone the repository**  
   ```bash
   git clone https://github.com/greeeen013/MacroRePlayer.git
   cd MacroRePlayer
- **Run the application**
   >A standalone `.exe` file will soon be available in the Release section once the program reaches a usable state.

---

### Requirements 🎯

  - none at this time

---

## Getting Started 🚀

### Open the application
After launching, the main interface will appear with options to **Record**, **Play**, or **Editor button**.

### Set up Keybinds (optional)
Choose a key (or a key combination, possibly as a future feature) to control recording and playback.

### Record a Macro
Click **Start Recording** and begin performing mouse and keyboard actions. When finished, click **Stop Recording** to end the session.

### Edit the Macro
Click the **Open Editor** button to open the Editor, where you can modify or fine-tune individual events and values as needed.

### Replay the Macro
Configure your replay mode and speed, then start playback.

---

## Detailed Use 📖

### Record
1. Click **Start Recoring** (or use a defined keybind).
2. The application begins recording all mouse and keyboard actions in the order they're performed.
3. When finished, click **Stop Recording** (or the same keybind) again to stop.
4. And it will save the sessions as `.json` files

### Edit
1. Click the **Open Editor** button
2. The Editor window will appear. Then, select your `.json` file from the dropdown menu to display a complete timeline of all recorded events in the list.
2. You can:
    - **↑/↓ Arrow Keys** – Move events up or down in the timeline. (Fun fact: Holding an arrow key will instantly move the selected event to the top/bottom!)
   - **Delete** - Remove unwanted events.
   - **Copy** actions to quickly duplicate the events.
   - **Extract** will delete and copy the action to quickly rearrange the events
   - **Insert** copied event under selected item
   - **Adjust time delays** between events.
   - Insert **conditions, loops** (TODO).

### (Re)Play
1. Set a **keybind** to **Start** / **Stop** the playback (optional). 
2. In the **Player** window, choose:
   - **Mode** (one-time, repeat X times, infinite) (TODO).
   - **Speed** (from 0.25× to 10×) (TODO).
3. Click **Start Playing Macro** (or use the defined keybind) to start (Re)Playing all recorded actions.
4. Playback can be **stopped** at any time using the same defined keybind or by pressing **Stop Playing Macro**.

---

## Configuration ⚙️ (TODO)
- the `.cfg` file should create automatically when needed to save some data and by default it should look like this
[Settings]
autosave = true
theme = "white"
default_speed = 1
startup_delay = 1000
hotkey_record = ""
hotkey_play = ""

## Planned Features 🗺️ (TODO)

- **Repeat**: Replay the macro a specific number of times or indefinitely.
- **Variable speeds**: Adjust playback speed up to 10× or slow it down to 0.25×.
- **Advanced loops**: Create your own loops or conditional logic (e.g.,`for loop`).
- **Save and load macros**: Export and share macros with others.
- **startup delay**
- **setting form**: with option tu execute macro in python (it won't be soon) and skin etc.
- **Full movement tracking** *(Planned, but not soon)* 

---

## Contribution

If you have suggestions for improvements or want to report a bug, feel free to open an **Issue** or submit a **Pull Request**. We welcome your contributions!

1. **Fork** this repository.  
2. **Create a new branch** for your feature.
   ```bash
   git checkout -b feature/your-feature
4. **Commit Changes:**
   ```bash
   git commit -m "feat: add amazing feature"
6. **Push & Create PR:**
   ```bash
   git push origin feature/your-feature
   
Thank you for your interest in MacroRePlayer! We hope it helps you automate repetitive tasks and allows you to focus on more important and creative work. If you have any questions or ideas, feel free to reach out in the [Issues](https://github.com/greeeen013/MacroRePlayer/issues).
