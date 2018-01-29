# PseudoRandomStrings
Productivity tool to generate random strings, emails, etc.

[![Build Status](https://travis-ci.org/arthrp/PseudoRandomStrings.svg?branch=master)](https://travis-ci.org/arthrp/PseudoRandomStrings)

Sometimes you need to come up with many different strings. Like when filling in some form in a web app. 
It can get cumbersome to produce many unique strings, so this is where this tool can help.
You can generate random strings, or random (valid) emails.

Generated strings are even put to clipboard automatically, which saves you some copy-pasting.
Unfortunately that API is not available in Mono, so auto-copying to clipboard is windows-only for the time being.

Work is underway to port it to .NET Core and refactor it finally (use proper way to parse command line arguments, for example). This project was hacked together in a weekend JFF, so code quality is quite awful.

**Warning**: As of now weak random source is used, to speed up the string generation.

Use it like:

PseudoRandomStrings [string length] [-type Email|String] [-loop]

First argument is a length of generated string.
You can specify -type of string, random alphanumeric or random email.

If you pass -loop, it will spin in an infinite loop, giving you new strings. Press 'q' to quit the loop.

Example:

PseudoRandomStrings 8 -type String

Will generate an alphanumeric string of 8 chars.
