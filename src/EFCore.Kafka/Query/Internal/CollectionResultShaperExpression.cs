﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*
*  Copyright 2022 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

namespace MASES.EntityFrameworkCore.Kafka.Query.Internal;

public class CollectionResultShaperExpression : Expression, IPrintableExpression
{
    public CollectionResultShaperExpression(
        Expression projection,
        Expression innerShaper,
        INavigationBase? navigation,
        Type elementType)
    {
        Projection = projection;
        InnerShaper = innerShaper;
        Navigation = navigation;
        ElementType = elementType;
    }

    public virtual Expression Projection { get; }

    public virtual Expression InnerShaper { get; }

    public virtual INavigationBase? Navigation { get; }

    public virtual Type ElementType { get; }

    /// <inheritdoc />
    public sealed override ExpressionType NodeType
        => ExpressionType.Extension;

    /// <inheritdoc />
    public override Type Type
        => Navigation?.ClrType ?? typeof(List<>).MakeGenericType(ElementType);

    /// <inheritdoc />
    protected override Expression VisitChildren(ExpressionVisitor visitor)
    {
        var projection = visitor.Visit(Projection);
        var innerShaper = visitor.Visit(InnerShaper);

        return Update(projection, innerShaper);
    }

    public virtual CollectionResultShaperExpression Update(
        Expression projection,
        Expression innerShaper)
        => projection != Projection || innerShaper != InnerShaper
            ? new CollectionResultShaperExpression(projection, innerShaper, Navigation, ElementType)
            : this;

    /// <inheritdoc />
    void IPrintableExpression.Print(ExpressionPrinter expressionPrinter)
    {
        expressionPrinter.AppendLine("CollectionResultShaperExpression:");
        using (expressionPrinter.Indent())
        {
            expressionPrinter.Append("(");
            expressionPrinter.Visit(Projection);
            expressionPrinter.Append(", ");
            expressionPrinter.Visit(InnerShaper);
            expressionPrinter.AppendLine($", {Navigation?.Name}, {ElementType.ShortDisplayName()})");
        }
    }
}
