/**
 * 
 * Catalog API 
 */
global using CatalogAPI.Models;
global using CatalogAPI.Exceptions;
global using CatalogAPI.Data;


/**
 * 
 * Common
 */
global using Common.CQRS;
global using Common.Behaviours;
global using Common.Exceptions.Handler;

/*
 * 
 * External
 */
// Routing and Minimal API
global using Carter;

// Object-to-object mapping
global using Mapster;

// CQRS Request / Response handling
global using MediatR;

// Request Validation
global using FluentValidation;

// Document/Event store ORM for PostgreSQL
global using Marten;
global using Marten.Pagination;
