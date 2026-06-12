# Tool Rental System

ASP.NET Web API system for managing tool rentals, returns, and payments.

## Description

This system allows a business to manage the rental of tools to customers.
It handles tool availability, rental registration, returns, late fees, and damage reports.

## Main Entities

* **Tool** – Physical tools available for rent
* **Customer** – People who rent tools
* **Rental** – The rental record linking a customer to a tool
* **Payment** – Payments associated with rentals

## Technologies

* C# / ASP.NET Web API
* Entity Framework Core
* SQL Server
* GitHub (version control)

## Project Status

In development – University project

## Author

* GitHub: EsmerlinM (https://github.com/EsmerlinM)



## Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) o SQL Server LocalDB
- [Visual Studio 2026](https://visualstudio.microsoft.com/)
- Git instalado y configurado


## Branch Strategy



This project follows a structured branching model to keep the codebase organized.



### Branch Types



| Branch | Purpose |

|--------|---------|

| `main` | Stable version. Only receives merges from `develop` after review. |

| `develop` | Main working branch. All features are integrated here. |

| `feature/issue-number-description` | One branch per issue. Created from `develop` and merged back into `develop`. |



### Workflow



1\. Pick an issue from the board and move it to \*\*In Progress\*\*

2\. Create a branch: `feature/issue-number-short-description`

3\. Make commits with descriptive messages

4\. Push and open a \*\*Pull Request\*\* targeting `develop`

5\. After review, merge the PR and close the issue

6\. Move the card to \*\*Done\*\* on the board



### Naming Convention Examples



- `feature/2-branch-strategy`

- `feature/3-folder-structure`

- `feature/4-readme-documentation`


##  Estado del Proyecto - Milestone 1

** MILESTONE 1 COMPLETADO - LISTO PARA ENTREGA**

| Issue | Descripción |
|-------|-------------|
| #1 | Create ASP.NET Web API project |
| #2 | Configure branch strategy |
| #3 | Create initial folder structure |
| #4 | Write initial project documentation |
| #5 | Plan entity structure |

**Fecha de entrega:** 11 de junio de 2026

**Rama principal:** `Develop`

**Enlace al repositorio:** https://github.com/EsmerlinM/tool-rental-system