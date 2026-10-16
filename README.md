RaceDay API

 Overview
RaceDay API is a web application built with ASP.NET Core and Entity Framework Core.  
It provides secure authentication, role‑based user handling, and event management features for race day competitions.

---

Features
- User Registration  
  - Supports Participants and Organisers.  
  - Passwords are hashed using BCrypt before saving.  

- User Login  
  - Verifies email + password against the database.  
  - Issues a JWT token for authentication.  

- Events  
  - Organisers can create events with title, date, and location.  

- Categories  
  - Each event can have multiple categories (e.g., 5km, 10km, age groups).  
  - Categories define divisions like distance, age group, gender, and max participants.  

- Enrolments  
  - Participants enrol into events under specific categories.  

- Results  
  - Records participant results tied to their event and category.  

---

Tech Stack
- ASP.NET Core Web API  
- Entity Framework Core (SQL Server)  
- JWT Authentication  
- BCrypt for password hashing  

---

Endpoints

🔹 Auth
- POST /api/Auth/register → Register new user  
- POST /api/Auth/login → Login and receive JWT token  

🔹 Events
- POST /api/Events → Create event  
- GET /api/Events → List events  

🔹 Categories
- POST /api/Categories → Create category for an event  
- GET /api/Categories → List categories  

🔹 Enrolments
- POST /api/Enrolments → Enrol participant into event category  

🔹 Results
- POST /api/Results → Record participant result  

---
Swagger Testing Flow
1. Register a Participant or Organiser.  
2. Login with email + password → copy JWT token.  
3. Authorize in Swagger using the token.  
4. Create Event (Organiser).  
5. Add Categories to the event.  
6. Enrol Participant into a category.  
7. Submit Result for the participant.  
