# Backuparr
**Backuparr** is a lightweight Docker service designed to back up folders in an *Arr stack (Sonarr, Radarr, Lidarr, etc.).

It runs on a configurable schedule, archives the selected folders, and stores them for safekeeping — perfect for self-hosters who want to protect their media metadata, configuration files, and more.

Retention is handled by **limiting the number of backups kept**, automatically deleting the oldest ones when the limit is reached.


## ✨ Features

- **Automated Backups** – Create periodic backups of your *Arr application folders.
- **Cron Scheduling** – Set a custom cron expression to control when backups run. *(upcoming)*
- **Retention Management** – Keep only the most recent N backups to save space.
- ~**Custom Backup Formats** – Choose the archive file format for your backups. *(upcoming)*~
- **Cloud Upload** – Send your backups to cloud storage for off-site protection. *(upcoming)*
- **One-Click Backup** – Trigger a backup instantly from the UI.
- **Configurable Paths** – Define which folders to back up and where to store them using `.env`.
- **Backup Listing** – View all stored backups directly from the UI. *(upcoming)*


## 📦 Docker Setup

### Using Docker CLI
```bash
docker run -d \
  --name=backuparr \
  -v /path/to/source:/source \
  -v /path/to/backups:/backups \
  -e HELLO="Hello world" \
  -e SOURCE_FOLDER=/source \
  -e DESTINATION_FOLDER=/backups \
  -e SIZE_RETENTION=4 \
  -e TZ=Europe/London \
  gabimotroc/backuparr
```

### Using Docker Compose

```yaml
version: "3.8"

services:
  backuparr:
    image: gabimotroc/backuparr:latest
    container_name: backuparr
    restart: unless-stopped
    environment:
      - HELLO=Hello world
      - SOURCE_FOLDER=/source
      - DESTINATION_FOLDER=/backups
      - SIZE_RETENTION=4
      - TZ=Europe/London
    volumes:
      - /path/on/host/source:/source
      - /path/on/host/backups:/backups
```