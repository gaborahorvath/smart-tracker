# 🚀 Smart Tracker - Full-Stack AI-Ready Task Management

Ez egy 5 szintből álló komplex fejlesztési projekt, amely a modern szoftverarchitektúra alapjaitól (Docker, MongoDB) a legújabb AI technológiákig (MCP) vezeti végig a fejlesztőt.

## 🏗️ Architektúra (Levels 1-5)

A projekt öt különálló technológiai szinten alapul:

- **Level 1 (Infrastructure):** Dockerizált MongoDB adatbázis biztosítja az adattárolást.
- **Level 2 (The Core):** ASP.NET Core Web API (C#) kezeli az üzleti logikát és a CRUD műveleteket.
- **Level 3 (The Interface):** Angular 17+ alapú frontend, Bootstrap 5-tel stílusozva a reszponzív élményért.
- **Level 4 (Microservices):** Python (FastAPI) alapú analitikai szerviz, amely statisztikákat gyárt a feladatokról.
- **Level 5 (Intelligence):** MCP (Model Context Protocol) szerver integráció, amely lehetővé teszi az AI számára az adatbázishoz való hozzáférést.

## 🛠️ Alkalmazott Technológiák

| Réteg | Technológia |
| :--- | :--- |
| **Backend** | .NET Core 8, C#, MongoDB Driver |
| **Frontend** | Angular, TypeScript, Bootstrap 5 |
| **Microservice** | Python 3.12, FastAPI, Uvicorn |
| **AI Layer** | MCP SDK, JSON-RPC via stdio |
| **DevOps** | Docker, Git, npm, NuGet |

## 🚀 Telepítés és Futtatás

1. **Adatbázis:** `docker-compose up -d`
2. **Backend:** `cd backend/SmartTracker.Api && dotnet run`
3. **Frontend:** `cd frontend && ng serve -o`
4. **Analytics:** `cd microservices/analytics-service && py app.py`
5. **AI Server:** `cd microservices/mcp-server && py mcp_app.py`

---
*Készítette: Horvath Gabor - 2026. Április*