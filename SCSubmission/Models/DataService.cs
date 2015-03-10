using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCSubmission.Models;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;

namespace SCSubmission.Models
{
    public static class DataService
    {

        public static ItemOfBusiness GetItemOfBusiness(string documentId)
        {
            var items = LoadItemsOfBusiness();

            return items.FirstOrDefault(x => x.DocumentId == documentId);
        }


        public static IEnumerable<ItemOfBusiness> LoadItemsOfBusiness()
        {
            String url = "http://www.parliament.nz/en-nz/syndication?posting=/en-nz/pb/sc/make-submission/";

            List<ItemOfBusiness> businessItems = new List<ItemOfBusiness>();

            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                ItemOfBusiness i = new ItemOfBusiness();
                i.DocumentId = item.Id;
                i.Title = item.Title.Text;
                i.ClosingDate = item.LastUpdatedTime.Date;

                var content = (TextSyndicationContent)item.Content;
                i.Description = content.Text;

                i.CommitteeName = LoadItemOfBusinessMetadata(i.DocumentId);
                i.CommitteeIconName = GetCommitteeIconName(i.CommitteeName);

                businessItems.Add(i);
            }

            businessItems.Reverse();

            return businessItems;
        }

        public static String LoadItemOfBusinessMetadata(String DocumentId)
        {
            String url = "http://www.parliament.nz/en-nz/Document/" + DocumentId + "/Metadata";

            int i = 0;

            using (XmlReader reader = XmlReader.Create(url))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "dd")
                        {
                            if (i == 2) // the select committee name is the third <dd>
                            {
                                XElement el = XNode.ReadFrom(reader) as XElement;
                                if (el != null)
                                {
                                    return el.Value;
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                    }
                }
            }

            return "";

        }

        private static string GetCommitteeIconName(string committeeName)
        {
            switch (committeeName)
            {
                case "Commerce Committee":
                    return "money.png";
                case "Education and Science Committee":
                    return "genius.png";
                case "Finance and Expenditure Committee":
                    return "trends.png";
                case "Foreign Affairs, Defence and Trade Committee":
                    return "globe.png";
                case "Government Administration Committee":
                    return "compose.png";
                case "Health Committee":
                    return "heart.png";
                case "Justice and Electoral Committee":
                    return "bookshelf.png";
                case "Law and Order Committee":
                    return "key.png";
                case "Local Government and Environment Committee":
                    return "flower.png";
                case "Māori Affairs Committee":
                    return "profile.png";
                case "Primary Production Committee":
                    return "tractor.png";
                case "Social Services Committee":
                    return "rgb.png";
                case "Transport and Industrial Relations Committee":
                    return "truck.png";

                case "Business Committee":
                    return "briefcase.png";
                case "Officers of Parliament Committee":
                    return "megaphone.png";
                case "Privileges Committee":
                    return "flag.png";
                case "Regulations Review Committee":
                    return "check.png";
                case "Standing Orders Committee":
                    return "booklet.png";
            }

            return "";
        }
    }
}