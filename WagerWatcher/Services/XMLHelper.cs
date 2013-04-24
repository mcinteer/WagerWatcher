using System.Xml.XPath;

namespace WagerWatcher.Services
{
    class XMLHelper
    {
        readonly XPathDocument _xmlDoc;
        readonly XPathNavigator _docNav;

        public XMLHelper(string uri)
        {
            _xmlDoc = new XPathDocument(uri);
            _docNav = _xmlDoc.CreateNavigator();
        }

        public XPathNodeIterator GetNodeSet(string xPath)
        {
            return _docNav.Select(xPath);
        }
    }
}
