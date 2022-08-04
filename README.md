> ## JsonDeserializing.
><p>
這是一個控制台程式，將內政部的不動產交易的Json文件序列化成自定義的物件，使用時須將檔案放置到執行檔目錄下的／JsonDocument文件夾下，
會先將Json文件序列化成List<Dictionrary<string, string>>並替換掉中文健值，使用物件的屬性當作新的鍵值，再反序列化為Json文件再
序列化為自定義物件，自定義物件的屬性之數量與類型需匹配Json文件
<br>[範例檔案](https:https://drive.google.com/file/d/1B-iUimD1lSzqc-HQilHHdJbGYSsCZovb/view?usp=sharing "範例檔案") </br>
</p>







