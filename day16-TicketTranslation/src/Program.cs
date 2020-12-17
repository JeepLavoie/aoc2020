using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketTranslation
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticketTranslator = new TicketTranslator(File.ReadAllLines("../input.txt"));

            //Part One
            Console.WriteLine(ticketTranslator.NearbyTicketValidator());

            //Part Two
            Console.WriteLine(ticketTranslator.YourTicketValidator("departure"));
        }
    }

    public record TicketTranslator
    {
        public List<Field> Fields { get; init; }
        public Ticket YourTicket { get; init; }
        public List<Ticket> NearbyTickets { get; init; }

        public TicketTranslator(IEnumerable<string> inputs)
        {
            var stage = 0;
            Fields = new List<Field>();
            NearbyTickets = new List<Ticket>();
            foreach (var input in inputs)
            {
                if (stage == 0)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        stage++;
                        continue;
                    }
                    Fields.Add(new Field(input));
                }

                if (stage == 1)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        stage++;
                        continue;
                    }
                    if (input.Contains("your")) continue;

                    YourTicket = new Ticket(input);
                }

                if (stage == 2)
                {
                    if (input.Contains("nearby")) continue;

                    NearbyTickets.Add(new Ticket(input));
                }
            }
        }

        public int NearbyTicketValidator()
        {
            var notOkValues = new List<int>();

            foreach (var ticket in NearbyTickets)
            {
                foreach (var value in ticket.Values)
                {
                    if (!Fields.Any(_ => _.IsValueValid(value)))
                        notOkValues.Add(value);
                }
            }

            return notOkValues.Sum(_ => _);
        }


        public long YourTicketValidator(string fieldName)
        {
            var validTicket = new List<Ticket>();

            foreach (var ticket in NearbyTickets)
            {
                var valid = true;
                foreach (var value in ticket.Values)
                {
                    if (!Fields.Any(_ => _.IsValueValid(value)))
                        valid = false;
                }
                if (valid) validTicket.Add(ticket);
            }

            var dic = new Dictionary<string, int>();
            var possibleFields = Fields.ToList();

            while (possibleFields.Count > 0)
            {

                for (var i = 0; i < YourTicket.Values.Count(); i++)
                {
                    foreach (var field in Fields)
                    {
                        foreach (var ticket in validTicket)
                        {
                            if (!field.IsValueValid(ticket.Values.ElementAt(i)))
                            {
                                possibleFields.Remove(field);
                                break;
                            }
                        }
                    }
                    if (possibleFields.Count == 1)
                        dic[possibleFields[0].Name] = i;

                    possibleFields = Fields.Where(_ => !dic.ContainsKey(_.Name)).ToList();
                }
            }

            return dic.Where(_ => _.Key.Contains(fieldName)).Aggregate(1L,(a,b) => a * YourTicket.Values.ElementAt(b.Value));
        }
    }

    public record Field
    {
        public string Name { get; init; }
        public int LowerRange1 { get; init; }
        public int HighRange1 { get; init; }
        public int LowerRange2 { get; init; }
        public int HighRange2 { get; init; }

        public Field(string input)
        {
            var split = input.Split(':').Select(_ => _.Trim()).ToList();
            Name = split[0];
            var range = split[1].Split(" or ");
            LowerRange1 = int.Parse(range[0].Split('-')[0]);
            HighRange1 = int.Parse(range[0].Split('-')[1]);
            LowerRange2 = int.Parse(range[1].Split('-')[0]);
            HighRange2 = int.Parse(range[1].Split('-')[1]);
        }

        public bool IsValueValid(int value) =>
             (value >= LowerRange1 && value <= HighRange1) || (value >= LowerRange2 && value <= HighRange2);
    }

    public record Ticket(IEnumerable<int> Values)
    {
        public Ticket(string input) : this(input.Split(',').Select(_ => int.Parse(_)))
        { }
    }
}
