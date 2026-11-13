# Folder Watcher Service

A simple **Folder Watcher Service** built using C# Windows Forms (.NET Framework 4.8). It monitors a selected folder and automatically records file activities with date and time.

## Features

- **Select Folder:** Choose any folder to monitor.
- **Start Watching:** Start monitoring folder activities.
- **Stop Watching:** Stop folder monitoring.
- **File Created:** Detect newly created files.
- **File Deleted:** Detect deleted files.
- **File Renamed:** Detect renamed files.
- **Activity Log:** Display all activities in the application.
- **Date & Time:** Record the date and time of every activity.
- **Log File:** Automatically save activities in `FolderLog.txt`.

## Technologies Used

- C#
- Windows Forms
- .NET Framework 4.8
- FileSystemWatcher
- Visual Studio

## Log File Example

```text
13-11-2026 09:15:20 AM - Watching Started
13-11-2026 09:16:10 AM - Created: Test.txt
13-11-2026 09:17:05 AM - Deleted: Demo.txt
13-11-2026 09:18:30 AM - Renamed: Old.txt
```

**Developed By:** Nitin
**Roll Number:** 2402371
**Branch:** Vocational IT
