# ⚽ Football Career Mode Companion – Backend

A Clean Architecture ASP.NET Core Web API designed to enhance immersion in football career mode playthroughs through structured data modeling and AI-generated narratives.

This backend allows users to manually log match results, track season progress, and generate dynamic match and season narratives based on accumulated data.

The focus of this project is:

* Strong backend architecture
* Domain-driven design principles
* Clean separation of concerns
* AI integration as a side effect (not core logic)
* Resume-grade implementation quality

---

# 🎯 Project Intent

Football career modes in games like FIFA / EA FC lack long-term storytelling and contextual immersion.

This system solves that by:

* Structuring match and season data manually
* Deriving narrative-relevant insights from stored data
* Feeding structured inputs into AI prompt builders
* Persisting generated narratives for future retrieval

The design prioritizes:

* Structured input over raw prompts
* Deterministic derivation logic
* Clean, extensible architecture
* Backend quality over UI polish

---

# 🏗 Architecture

The project follows Clean Architecture principles:

Domain
Application
Infrastructure
API

## Domain

* Core entities: User, Career, Season, Match, MatchEvent
* Encapsulated business logic
* Private setters with controlled mutation methods
* Aggregate boundaries respected

## Application

* Use cases (SubmitMatch, CreateCareer, EndSeason, etc.)
* AI input builders
* Orchestrators
* DTOs
* Repository interfaces
* Security abstractions (IJwtTokenGenerator, IPasswordHasher)

## Infrastructure

* EF Core persistence (SQL Server)
* Entity configurations
* Repository implementations
* JWT token generation
* Password hashing (BCrypt)

## API

* Controllers
* JWT middleware configuration
* Route definitions
* Authorization enforcement

---

# 🔐 Authentication

JWT-based authentication implemented with:

* User registration
* Secure password hashing (BCrypt)
* Stateless JWT generation
* Claim-based user identity (`sub` claim)
* Controller-level `[Authorize]` enforcement

Career ownership is enforced via:

Career → UserId (Foreign Key)

All career and season queries are scoped to the authenticated user.

---

# 🧠 Core Features Implemented

## 👤 Users

* Register
* Login
* JWT token generation
* Authenticated resource access

---

## 🏟 Career Management

* Create career
* Associate career with authenticated user
* Retrieve user-scoped careers

Career includes:

* Name
* ClubName
* ManagerName
* CreatedAt
* UserId

---

## 📅 Season Management

* Create season under career
* End season
* Update league position
* Retrieve seasons by career
* Track board expectation (enum)

Season includes:

* StartDate (derived on first match)
* EndDate
* LeaguePosition
* BoardExpectation
* Derived metrics for narrative building

---

## ⚽ Match Submission

* Manual match input
* Idempotency check
* Goal events with minute tracking
* League position before/after tracking
* Automatic season start date initialization
* Optional league position update

Match tracks:

* Competition
* Opponent
* Venue
* Goals
* Goal events
* League position delta

---

# 🤖 AI Narrative System

AI is treated as a side effect, not core domain logic.

## Match Narrative Pipeline

1. Match submitted
2. MatchNarrativeInputBuilder derives structured data
3. PromptBuilder formats AI input
4. IMatchNarrativeGenerator generates content (currently fake implementation)
5. NarrativeSnapshot persisted

Includes:

* Recent form
* Recent head-to-head
* Goal timeline
* Result context

---

## Season Narrative Pipeline

User-triggered generation:

1. SeasonNarrativeInputBuilder derives:

   * Wins, draws, losses
   * Goal distribution by phase
   * Top scorers
   * Venue records
   * Notable matches
   * Tone hints
2. PromptBuilder constructs season prompt
3. NarrativeSnapshot persisted

Season narrative supports:

* Mid-season invocation
* End-of-season invocation
* Deterministic tone guidance

---

# 🗃 Database

* SQL Server
* EF Core (code-first)
* Explicit migrations
* Clean baseline reset during development

Key relationships:

User 1 → N Career
Career 1 → N Season
Season 1 → N Match
Match 1 → N MatchEvent

---

# 🔍 Design Philosophy

This backend intentionally:

* Avoids scraping or automatic stat ingestion
* Prioritizes structured derived data
* Avoids domain leakage into controllers
* Uses DTOs for API responses
* Returns empty collections instead of null
* Treats enums as domain primitives
* Converts enums to strings only at API boundary
* Keeps AI isolated from core domain logic

---

# 🚀 Technology Stack

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt password hashing
* Clean Architecture layering

---

# 🔧 Setup Instructions

## 1️⃣ Clone repository

## 2️⃣ Configure JWT Secret

Set environment variable:

Windows:

setx Jwt__Key "YOUR_SECRET_KEY"

Restart terminal / IDE afterward.

---

## 3️⃣ Configure Database

Edit `appsettings.Development.json`:

{
"ConnectionStrings": {
"DefaultConnection": "Server=.;Database=FootballCareerCompanion;Trusted_Connection=True;TrustServerCertificate=True;"
}
}

---

## 4️⃣ Apply Migrations

```
dotnet ef database update
```

---

## 5️⃣ Run API

```
dotnet run
```

---

# 📌 Current Scope

Implemented:

* JWT authentication
* User-scoped careers
* Season lifecycle
* Match submission
* AI narrative pipeline (match + season)
* Structured DTO-based API responses
* Clean repository pattern

Not implemented yet:

* Frontend
* Real AI provider integration
* Refresh tokens
* Role-based authorization
* Competition entity abstraction
* Advanced statistics engine

---

# 📈 Future Improvements

* Competition abstraction (league vs cup tracking)
* Assist tracking
* Advanced narrative tone logic
* Role-based access
* Async background AI jobs
* Real AI API integration
* Performance analytics

---

# 💡 Why This Project Exists

This project demonstrates:

* Architectural maturity
* Clean separation of concerns
* Thoughtful domain modeling
* AI system integration discipline
* Real-world backend practices

It is intentionally backend-heavy to showcase engineering depth over UI flash.
