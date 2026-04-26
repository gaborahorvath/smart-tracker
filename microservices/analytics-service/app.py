from fastapi import FastAPI
from pymongo import MongoClient
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()

# CORS engedélyezése, hogy az Angular (4200-as port) elérje
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_methods=["*"],
    allow_headers=["*"],
)

# MongoDB kapcsolat (Dockerben futó adatbázis)
client = MongoClient("mongodb://localhost:27017/")
db = client["SmartTrackerDb"]
collection = db["Tasks"]

@app.get("/api/analytics/stats")
def get_stats():
    all_tasks = list(collection.find())
    total = len(all_tasks)
    todo = len([t for t in all_tasks if t.get('status') == 'Todo'])
    
    return {
        "totalTasks": total,
        "todoCount": todo,
        "message": "Elemzés sikeresen lefutott a Python microservice-ben!"
    }

if __name__ == "__main__":
    import uvicorn
    # A 8000-es porton fog figyelni (a .NET az 5151-en, az Angular a 4200-on fut)
    uvicorn.run(app, host="0.0.0.0", port=8000)