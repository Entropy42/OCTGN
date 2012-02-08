﻿using System;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace Octgn.Server
{
    internal abstract class BaseXmlStub : IClientCalls
    {
        private readonly Handler handler;
        protected XmlWriterSettings xmlSettings = new XmlWriterSettings();

        protected BaseXmlStub(Handler handler)
        {
            xmlSettings.OmitXmlDeclaration = true;
            this.handler = handler;
        }

        #region IClientCalls Members

        public void Binary()
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Binary");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Ping()
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Ping");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void IsAlternate(int c, bool isAlternate)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("IsAlternate");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("cardid", c.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("isalternate", isAlternate.ToString());
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }
        public void IsAlternateImage(int c, bool isAlternateImage)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("IsAlternateImage");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("cardid", c.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("isalternateimage", isAlternateImage.ToString());
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Error(string msg)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Error");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("msg", msg);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Welcome(byte id)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Welcome");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Settings(bool twoSidedTable)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Settings");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("twoSidedTable", twoSidedTable.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void PlayerSettings(byte playerId, bool invertedTable)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("PlayerSettings");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("playerId", playerId.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("invertedTable", invertedTable.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void NewPlayer(byte id, string nick, ulong pkey)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("NewPlayer");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("nick", nick);
            writer.WriteElementString("pkey", pkey.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Leave(byte player)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Leave");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Nick(byte player, string nick)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Nick");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("nick", nick);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Start()
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Start");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Reset(byte player)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Reset");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void NextTurn(byte nextPlayer)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("NextTurn");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("nextPlayer", nextPlayer.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void StopTurn(byte player)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("StopTurn");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Chat(byte player, string text)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Chat");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("text", text);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Print(byte player, string text)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Print");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("text", text);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Random(byte player, int id, int min, int max)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Random");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("min", min.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("max", max.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void RandomAnswer1(byte player, int id, ulong value)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("RandomAnswer1");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("value", value.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void RandomAnswer2(byte player, int id, ulong value)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("RandomAnswer2");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("value", value.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Counter(byte player, int counter, int value)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Counter");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("counter", counter.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("value", value.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void LoadDeck(int[] id, ulong[] type, int[] group)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("LoadDeck");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (int p in id)
                writer.WriteElementString("id", p.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in type)
                writer.WriteElementString("type", p.ToString(CultureInfo.InvariantCulture));
            foreach (int g in group)
                writer.WriteElementString("group", g.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void CreateCard(int[] id, ulong[] type, int group)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("CreateCard");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (int p in id)
                writer.WriteElementString("id", p.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in type)
                writer.WriteElementString("type", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void CreateCardAt(int[] id, ulong[] key, Guid[] modelId, int[] x, int[] y, bool faceUp, bool persist)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("CreateCardAt");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (int p in id)
                writer.WriteElementString("id", p.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in key)
                writer.WriteElementString("key", p.ToString(CultureInfo.InvariantCulture));
            foreach (Guid g in modelId)
                writer.WriteElementString("modelId", g.ToString());
            foreach (int p in x)
                writer.WriteElementString("x", p.ToString(CultureInfo.InvariantCulture));
            foreach (int p in y)
                writer.WriteElementString("y", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("faceUp", faceUp.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("persist", persist.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void CreateAlias(int[] id, ulong[] type)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("CreateAlias");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (int p in id)
                writer.WriteElementString("id", p.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in type)
                writer.WriteElementString("type", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void MoveCard(byte player, int card, int group, int idx, bool faceUp)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("MoveCard");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("idx", idx.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("faceUp", faceUp.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void MoveCardAt(byte player, int card, int x, int y, int idx, bool faceUp)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("MoveCardAt");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("x", x.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("y", y.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("idx", idx.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("faceUp", faceUp.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Reveal(int card, ulong revealed, Guid guid)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Reveal");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("revealed", revealed.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("guid", guid.ToString());
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void RevealTo(byte[] players, int card, ulong[] encrypted)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("RevealTo");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (byte p in players)
                writer.WriteElementString("players", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in encrypted)
                writer.WriteElementString("encrypted", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Peek(byte player, int card)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Peek");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Untarget(byte player, int card)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Untarget");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Target(byte player, int card)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Target");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void TargetArrow(byte player, int card, int otherCard)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("TargetArrow");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("otherCard", otherCard.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Highlight(int card, string color)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Highlight");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("color", color);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Turn(byte player, int card, bool up)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Turn");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("up", up.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Rotate(byte player, int card, CardOrientation rot)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Rotate");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("rot", rot.ToString());
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Shuffle(int group, int[] card)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Shuffle");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            foreach (int p in card)
                writer.WriteElementString("card", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Shuffled(int group, int[] card, short[] pos)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Shuffled");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            foreach (int p in card)
                writer.WriteElementString("card", p.ToString(CultureInfo.InvariantCulture));
            foreach (short p in pos)
                writer.WriteElementString("pos", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void UnaliasGrp(int group)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("UnaliasGrp");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void Unalias(int[] card, ulong[] type)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("Unalias");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            foreach (int p in card)
                writer.WriteElementString("card", p.ToString(CultureInfo.InvariantCulture));
            foreach (ulong p in type)
                writer.WriteElementString("type", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void AddMarker(byte player, int card, Guid id, string name, ushort count)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("AddMarker");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("name", name);
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void RemoveMarker(byte player, int card, Guid id, string name, ushort count)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("RemoveMarker");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("name", name);
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void SetMarker(byte player, int card, Guid id, string name, ushort count)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("SetMarker");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("card", card.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("name", name);
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void TransferMarker(byte player, int from, int lTo, Guid id, string name, ushort count)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("TransferMarker");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("from", from.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("lTo", lTo.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("name", name);
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void PassTo(byte player, int id, byte lTo, bool requested)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("PassTo");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("lTo", lTo.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("requested", requested.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void TakeFrom(int id, byte lTo)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("TakeFrom");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("lTo", lTo.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void DontTake(int id)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("DontTake");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("id", id.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void FreezeCardsVisibility(int group)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("FreezeCardsVisibility");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void GroupVis(byte player, int group, bool defined, bool visible)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("GroupVis");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("defined", defined.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("visible", visible.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void GroupVisAdd(byte player, int group, byte who)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("GroupVisAdd");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("who", who.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void GroupVisRemove(byte player, int group, byte who)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("GroupVisRemove");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("who", who.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void LookAt(byte player, int uid, int group, bool look)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("LookAt");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("uid", uid.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("look", look.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void LookAtTop(byte player, int uid, int group, int count, bool look)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("LookAtTop");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("uid", uid.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("look", look.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void LookAtBottom(byte player, int uid, int group, int count, bool look)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("LookAtBottom");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("uid", uid.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("group", group.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("count", count.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("look", look.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void StartLimited(byte player, Guid[] packs)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("StartLimited");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            foreach (Guid g in packs)
                writer.WriteElementString("packs", g.ToString());
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void CancelLimited(byte player)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("CancelLimited");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("player", player.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        #endregion

        protected abstract void Send(string xml);

        public void PlayerSetGlobalVariable(byte from, byte p, string n, string v)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("PlayerSetGlobalVariable");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("from", from.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("who", p.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("name", n);
            writer.WriteElementString("value", v);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }

        public void SetGlobalVariable(string n, string v)
        {
            var sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSettings);

            writer.WriteStartElement("SetGlobalVariable");
            if (handler.muted != 0)
                writer.WriteAttributeString("muted", handler.muted.ToString(CultureInfo.InvariantCulture));
            writer.WriteElementString("name", n);
            writer.WriteElementString("value", v);
            writer.WriteEndElement();
            writer.Close();
            Send(sb.ToString());
        }
    }

    internal class XmlSenderStub : BaseXmlStub
    {
        private readonly TcpClient to;
        private byte[] buffer = new byte[1024];

        public XmlSenderStub(TcpClient to, Handler handler)
            : base(handler)
        {
            this.to = to;
        }

        protected override void Send(string xml)
        {
            int length = Encoding.UTF8.GetByteCount(xml) + 1;
            if (length > buffer.Length) buffer = new byte[length];
            Encoding.UTF8.GetBytes(xml, 0, xml.Length, buffer, 0);
            buffer[length - 1] = 0;
            try
            {
                Stream stream = to.GetStream();
                stream.Write(buffer, 0, length);
                stream.Flush();
            }
            catch
            {
                // TODO: notify disconnections
                //				if (Program.Server != null && Program.Server.Disconnected(lTo))
                //					return;
                //				Program.Client.Disconnected();
            }
        }
    }
}