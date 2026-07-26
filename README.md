Poker Full House Detector

A C# console program that models playing cards and a deck, then uses LINQ to identify full houses (three-of-a-kind + a pair) from a set of poker hands.

For each hand, it:

Groups cards by their Type.
Confirms there are exactly two distinct card values in the hand (required shape for a full house).
Confirms one group has exactly 3 cards (the three-of-a-kind).
Confirms the other group has exactly 2 cards (the pair).

Hands matching all three conditions are selected and printed via get_description().

Sample Hands & Expected Output

The program checks three sample hands:

Three 3's + two 7's → full house
Three 5's + two 2's → full house
Three 10's + an 8 + a 9 → not a full house (no pair)
