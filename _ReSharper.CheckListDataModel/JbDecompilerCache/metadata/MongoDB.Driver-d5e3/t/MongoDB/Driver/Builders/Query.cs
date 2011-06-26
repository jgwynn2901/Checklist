// Type: MongoDB.Driver.Builders.Query
// Assembly: MongoDB.Driver, Version=1.0.0.4098, Culture=neutral, PublicKeyToken=f686731cfb9cc103
// Assembly location: C:\Program Files (x86)\MongoDB\CSharpDriver 1.0\MongoDB.Driver.dll

using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Driver.Builders
{
    public static class Query
    {
        public static IMongoQuery Null { get; }
        public static QueryConditionList All(string name, BsonArray values);
        public static QueryConditionList All(string name, params BsonValue[] values);
        public static QueryComplete And(params QueryComplete[] queries);
        public static QueryConditionList ElemMatch(string name, QueryComplete query);
        public static QueryComplete EQ(string name, BsonValue value);
        public static QueryConditionList Exists(string name, bool exists);
        public static QueryConditionList GT(string name, BsonValue value);
        public static QueryConditionList GTE(string name, BsonValue value);
        public static QueryConditionList In(string name, BsonArray values);
        public static QueryConditionList In(string name, params BsonValue[] values);
        public static QueryConditionList LT(string name, BsonValue value);
        public static QueryConditionList LTE(string name, BsonValue value);
        public static QueryComplete Matches(string name, BsonRegularExpression regex);
        public static QueryConditionList Mod(string name, int modulus, int equals);
        public static QueryConditionList NE(string name, BsonValue value);
        public static QueryConditionList Near(string name, double x, double y);
        public static QueryConditionList Near(string name, double x, double y, double maxDistance);
        public static QueryConditionList Near(string name, double x, double y, double maxDistance, bool spherical);
        public static QueryConditionList NotIn(string name, BsonArray values);
        public static QueryConditionList NotIn(string name, params BsonValue[] values);
        public static QueryNot Not(string name);
        public static QueryComplete Or(params QueryComplete[] queries);
        public static QueryConditionList Size(string name, int size);
        public static QueryConditionList Type(string name, BsonType type);
        public static QueryComplete Where(BsonJavaScript javaScript);
        public static QueryConditionList WithinCircle(string name, double centerX, double centerY, double radius);
        public static QueryConditionList WithinCircle(string name, double centerX, double centerY, double radius, bool spherical);
        public static QueryConditionList WithinRectangle(string name, double lowerLeftX, double lowerLeftY, double upperRightX, double upperRightY);
    }
}
