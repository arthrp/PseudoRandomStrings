# PseudoRandomStrings
Productivity tool to generate random strings, emails, etc.

[![Build Status](https://travis-ci.org/arthrp/PseudoRandomStrings.svg?branch=master)](https://travis-ci.org/arthrp/PseudoRandomStrings)

Sometimes you need to come up with many different strings. Like when filling in some form in a web app. 
It can get cumbersome to produce many unique strings, so this is where this tool can help.
You can generate random strings, or random (valid) emails, more options to be added later (probably).

Generated strings are even put to clipboard automatically, which saves you some copy-pasting.
Unfortunately that API is not available in Mono, so auto-copying to clipboard is windows-only for the time being.

Use it like:

PseudoRandomStrings [string length] [-type Email|String] [-loop]

First argument is a length of generated string.
You can specify -type of string, random alphanumeric or random email.
If you pass -loop, it will spin in an infinite loop, giving you new strings. Press 'q' to quit the loop.
