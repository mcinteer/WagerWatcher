using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace WagerWatcher
{
    class XMLHelper
    {
        XPathDocument _xmlDoc;
        XPathNavigator _docNav;

        public XMLHelper(string uri)
        {
            _xmlDoc = new XPathDocument(uri);
            _docNav = _xmlDoc.CreateNavigator();
        }

        public XPathNodeIterator getNodeSet(string xPath)
        {
            return _docNav.Select(xPath);
        }
    }
}
