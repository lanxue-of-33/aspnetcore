// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text.Json.Serialization.Metadata;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Microsoft.AspNetCore.OpenApi;

/// <summary>
/// Represents the context in which an OpenAPI schema transformer is executed.
/// </summary>
public sealed class OpenApiSchemaTransformerContext
{
    private Type? _type;
    private JsonTypeInfo? _jsonTypeInfo;
    private JsonPropertyInfo? _jsonPropertyInfo;

    /// <summary>
    /// Gets the name of the associated OpenAPI document.
    /// </summary>
    public required string DocumentName { get; init; }

    /// <summary>
    /// Gets the <see cref="Type" /> associated with the current <see cref="OpenApiSchema"/>.
    /// </summary>
    public required Type Type { get => _type!; init => _type = value; }

    /// <summary>
    /// Gets the <see cref="ApiParameterDescription"/> associated with the target schema.
    /// Null when processing an OpenAPI schema for a response type.
    /// </summary>
    public required ApiParameterDescription? ParameterDescription { get; init; }

    /// <summary>
    /// Gets the <see cref="JsonTypeInfo"/> associated with the target schema.
    /// </summary>
    public required JsonTypeInfo JsonTypeInfo { get => _jsonTypeInfo!; init => _jsonTypeInfo = value; }

    /// <summary>
    /// Gets the <see cref="JsonPropertyInfo"/> associated with the target schema if the
    /// target schema is a property of a parent schema.
    /// </summary>
    public required JsonPropertyInfo? JsonPropertyInfo { get => _jsonPropertyInfo; init => _jsonPropertyInfo = value; }

    /// <summary>
    /// Gets the application services associated with the current document the target schema is in.
    /// </summary>
    public required IServiceProvider ApplicationServices { get; init; }

    internal void SetType(Type type) => _type = type;
    internal void SetJsonTypeInfo(JsonTypeInfo jsonTypeInfo) => _jsonTypeInfo = jsonTypeInfo;
    internal void SetJsonPropertyInfo(JsonPropertyInfo? jsonPropertyInfo) => _jsonPropertyInfo = jsonPropertyInfo;
}
