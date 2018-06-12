using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace NorthwindKataRepository.Extensions
{
    public static class IQueryableExtensions
    {
        private static readonly PropertyInfo DatabaseDependenciesField;

        private static readonly FieldInfo DataBaseField;

        private static readonly FieldInfo QueryCompilerField;

        private static readonly TypeInfo QueryCompilerTypeInfo;

        private static readonly FieldInfo QueryModelGeneratorField;

        static IQueryableExtensions()
        {
            QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();
            DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
            QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

            DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");
            QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
        }

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = QueryCompilerField.GetValue(query.Provider) as QueryCompiler;
            var modelGenerator = QueryModelGeneratorField.GetValue(queryCompiler) as QueryModelGenerator;
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = DataBaseField.GetValue(queryCompiler) as IDatabase;
            var databaseDependencies = DatabaseDependenciesField.GetValue(database) as DatabaseDependencies;
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = queryCompilationContext.CreateQueryModelVisitor() as RelationalQueryModelVisitor;
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}