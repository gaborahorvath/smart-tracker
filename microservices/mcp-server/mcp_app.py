from mcp.server.fastmcp import FastMCP
from pymongo import MongoClient

# MCP szerver inicializálása
mcp = FastMCP("SmartTracker")

# MongoDB kapcsolat
client = MongoClient("mongodb://localhost:27017/")
db = client["SmartTrackerDb"]
collection = db["Tasks"]

@mcp.tool()
def get_all_tasks() -> str:
    """Lekéri az összes feladatot az adatbázisból az AI számára."""
    tasks = list(collection.find({}, {"_id": 0}))
    if not tasks:
        return "Nincsenek feladatok az adatbázisban."
    
    result = "Aktuális feladatok:\n"
    for t in tasks:
        result += f"- {t['title']}: {t['description']} [{t['status']}]\n"
    return result

@mcp.tool()
def get_task_summary() -> str:
    """Összegzést készít a feladatok állapotáról."""
    tasks = list(collection.find())
    total = len(tasks)
    todo = len([t for t in tasks if t.get('status') == 'Todo'])
    return f"Összesen {total} feladat van, amiből {todo} még elvégzésre vár."

if __name__ == "__main__":
    mcp.run()