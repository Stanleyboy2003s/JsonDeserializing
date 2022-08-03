// See https://aka.ms/new-console-template for more information



StreamReader sr = new StreamReader("./JsonDocument/111年1月1日至111年3月31日買賣案件_ALL.json");
string jsonString = sr.ReadToEnd();

//先將整份文件字串反序列化為List<Dictionary<string, string>>集合，原文件為物件陣列，再將物件元素轉化成Dictionary<string, string>
List<Dictionary<string, string>> map = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonString);

Console.WriteLine("輸出2個原始Json文件反序列化的集合");
Console.WriteLine("===============================================");
for (int i = 0; i < 2; i++)
{
    foreach (var item in map[i])
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }
    Console.WriteLine("===============================================");
}


IList<JsonObject> JsonObjectList = new List<JsonObject>();
//使用stopwatch計時
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
Console.WriteLine("開始轉換，並計時");
for (int i = 0; i < map.Count; i++)
{
   //使用反射將原無件的KEY值轉換成物件之屬性名稱
    Type t = typeof(JsonObject);
    var PropertyList = t.GetProperties();
    Dictionary<string, string> NewJsonElement = new Dictionary<string, string>();
    for (int j = 0; j < map.ElementAt(i).Count; j++)
    {
        NewJsonElement.Add(PropertyList[j].Name, map.ElementAt(i).Select(c => c.Value).ToArray()[j]);
    }
    map[i] = NewJsonElement;
    string NewjsonString = JsonConvert.SerializeObject(map[i], Formatting.Indented);
    //Console.WriteLine(NewjsonString);
    //Console.WriteLine("============================");
    JsonObjectList.Add(JsonConvert.DeserializeObject<JsonObject>(NewjsonString));
}
stopwatch.Stop();
Console.WriteLine($"轉換完畢，消耗時間為:{stopwatch.Elapsed.TotalMilliseconds} ms");
Console.WriteLine("===============================================");

Console.WriteLine("輸出2個JsonObject的各項鍵值與數值");
Console.WriteLine("===============================================");
for (int i = 0; i < 2; i++)
{
   var PropertyList = typeof(JsonObject).GetProperties();
    foreach (var item in PropertyList)
    {
        Console.WriteLine($"{item.Name} : {item.GetValue(JsonObjectList[i])}");
    }
    Console.WriteLine("===============================================");
}
