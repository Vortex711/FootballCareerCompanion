# ⚽ Football Career Mode Companion – Backend

A Clean Architecture ASP.NET Core Web API designed to enhance immersion in football career mode playthroughs through structured data modeling and AI-generated narratives.

This backend allows users to manually log match results, track season progress, and generate grounded football narratives based on accumulated data.

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
* Persisting generated narratives as immutable historical records

The design prioritizes:

* Structured input over raw prompts
* Deterministic derivation logic
* Backend clarity over feature count
* Narrative consistency over regeneration

---

# 🏗 Architecture

The project follows Clean Architecture principles:

Domain
Application
Infrastructure
API

## Domain

* Core entities: User, Career, Season, Match, MatchEvent, NarrativeSnapshot
* Encapsulated business logic
* Private setters with controlled mutation methods
* Aggregate boundaries respected

## Application

* Use cases (SubmitMatch, CreateCareer, EndSeason, etc.)
* AI input builders (structured data derivation)
* Prompt builders
* Narrative orchestration
* DTOs
* Repository interfaces
* Security abstractions (IJwtTokenGenerator, IPasswordHasher)

## Infrastructure

* EF Core persistence (SQL Server)
* Repository implementations
* JWT token generation
* Password hashing (BCrypt)
* LLM provider integration (Gemini)

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

All queries are scoped to the authenticated user.

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
* Retrieve user-scoped careers

---

## 📅 Season Management

* Create season under career
* End season (explicit trigger)
* Retrieve seasons by career
* Track board expectation

Season includes:

* StartDate (derived)
* EndDate
* LeaguePosition
* BoardExpectation

---

## ⚽ Match Submission

* Manual match input
* Goal event tracking
* League position before/after tracking
* Automatic season initialization
* Narrative generation trigger

---

# 🤖 AI Narrative System

AI is treated as a **side effect**, not core domain logic.

Narratives are:

> Generated once → stored → never regenerated

This ensures consistency and historical integrity.

---

## Match Narrative Pipeline

1. Match submitted
2. Structured input derived (MatchNarrativeInputBuilder)
3. Prompt constructed (PromptBuilder)
4. LLM called via abstraction (Gemini provider)
5. NarrativeSnapshot persisted

Includes:

* Recent form
* Head-to-head context
* Goal timing
* League position impact

---

## Season Narrative Pipeline

Triggered explicitly when ending a season:

1. Aggregated data derived across matches
2. Prompt constructed with contextual constraints
3. LLM generates season summary
4. NarrativeSnapshot persisted

Key characteristics:

* Single summary per season
* No regeneration
* No mid-season summaries
* Focus on narrative continuity

---

# 🧠 AI Design Principles

* AI never accesses EF entities directly
* All inputs are structured DTOs
* Prompts are deterministic and constraint-driven
* Outputs are persisted snapshots
* Provider-specific logic is isolated in Infrastructure

---

# 🗃 Database

* SQL Server
* EF Core (code-first)

Relationships:

User 1 → N Career
Career 1 → N Season
Season 1 → N Match
Match 1 → N MatchEvent
Match/Season → NarrativeSnapshot

---

# 🔍 Design Philosophy

This backend intentionally:

* Avoids scraping or automation
* Uses manual input as a design choice
* Prioritizes meaning over analytics
* Keeps AI isolated from business logic
* Avoids feature creep (no dashboards, no social features)
* Treats narratives as memory, not dynamic output

---

# 🚀 Technology Stack

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt password hashing
* Google Gemini API (LLM integration)
* Clean Architecture

---

# 🔧 Setup Instructions

## 1️⃣ Clone repository

## 2️⃣ Configure JWT Secret

setx Jwt__Key "YOUR_SECRET_KEY"

---

## 3️⃣ Configure Database

Edit `appsettings.Development.json`:

{
"ConnectionStrings": {
"DefaultConnection": "Server=.;Database=FootballCareerCompanion;Trusted_Connection=True;TrustServerCertificate=True;"
}
}

---

## 4️⃣ Configure LLM Key

Add your Gemini API key:

setx Gemini__ApiKey "YOUR_API_KEY"

---

## 5️⃣ Apply Migrations

dotnet ef database update

---

## 6️⃣ Run API

dotnet run

---

# 📌 Current Scope (MVP)

Implemented:

* JWT authentication
* User-scoped careers
* Season lifecycle (explicit end)
* Match submission
* AI narrative generation (match + season)
* Snapshot-based persistence
* Clean architecture layering

Not implemented:

* Frontend
* Narrative regeneration
* Advanced analytics
* Background job processing
* Multi-provider AI switching

---

# 💡 Why This Project Exists

This project demonstrates:

* Clean Architecture in practice
* Domain-driven backend design
* Structured AI integration (not prompt hacks)
* Separation of concerns at scale
* Thoughtful system boundaries

It is intentionally backend-focused to showcase engineering depth and system design clarity.
