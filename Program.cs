// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System.Xml;

/*String xmlFilePath = "myfile.xml";
var mens = xmlFilePath.Replace("<.*?>", string.Empty);
string text = File.ReadAllText(mens);
await File.WriteAllTextAsync("WriteText.txt", text);*/

class Program
{
    static void Main(string[] args)
    {
        string contents = string.Empty;

        XmlDocument document = new XmlDocument();
        //document.LoadXml("<outer>a<b>b</b>c<i>d</i>e<b>f</b>g</outer>");
        document.Load("COBRANCA_EMISSAO_BOLETO_apenas-1-Original.xml");

        XmlNode root = document.DocumentElement;
        
        //XmlNodeList xnList = root.SelectNodes("/COBRANCAS//COBRANCA");

     /*     //Display all the book titles.
        XmlNodeList elemList = document.GetElementsByTagName("COBRANCA");
        for (int i = 0; i < elemList.Count; i++)
        {
           // Console.WriteLine(elemList[i].InnerXml);
           // Console.ReadKey();
           foreach(XmlNode child in elemList[i])
        {
            
            contents += child.InnerText + ";";
        }
        } */

        //foreach(XmlNode child in document.DocumentElement.ChildNodes)
        
        /* foreach(XmlNode child in xnList)
        {
            
            contents += child.InnerText + ";";

            /* int childnodes = child.ChildNodes.Count;
            for (int i = 0; i < childnodes; i++)
            {
              contents += child.ChildNodes[i].InnerText + ";";
            } */
            
            /*  if (child.NodeType == XmlNodeType.Element)
            { 
            }*/
      //  }

      XmlNode child = BuscaXml(document, "COBRANCA");
        foreach(XmlNode _child in child)
        {
            if(_child.InnerText != "")
            {
            contents += _child.InnerText + ";";
            }
        }
        File.WriteAllTextAsync("WriteText.txt", contents);
        Console.WriteLine(contents);

        Console.ReadKey(); 
    }

    //Funcao Recursiva
//É capaz de nos retornar a referencia de qualquer nó no arquivo xml
//sendo descendente do no passado na funcao.
public static XmlNode? BuscaXml(XmlNode node, String NodeName)
{
    //se é o que estamos procurando, o retorna
    if (node.Name == NodeName)
        return node;
    //caso este no nao possua filhos, retorne null
    if (node.ChildNodes.Count == 0)
        return null;
 
    XmlNode No_temp;
    //para cada filho de um determinado nó.
    foreach (XmlNode no in node.ChildNodes)
    {
        //inicia recursao
        No_temp = BuscaXml(no, NodeName);
         
        //caso nao exista, continua a iteracao
        if (No_temp == null)
            continue;
        //caso exista, retorne para continuar a busca
        else
            return No_temp;
    }
    //caso nao encontre...
    return null;
} 

}