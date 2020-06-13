# mdfind Usage Examples

```zsh
➜  mdcards git:(master) ✗ mdfind --help

Usage: mdfind [-live] [-count] [-onlyin directory] [-name fileName | -s smartFolderName | query]
list the files matching the query
query can be an expression or a sequence of words

	-attr <attr>      Fetches the value of the specified attribute
	-count            Query only reports matching items count
	-onlyin <dir>     Search only within given directory
	-live             Query should stay active
	-name <name>      Search on file name only
	-reprint          Reprint results on live update
	-s <name>         Show contents of smart folder <name>
	-0                Use NUL (``\0'') as a path separator, for use with xargs -0.

example:  mdfind image
example:  mdfind -onlyin ~ image
example:  mdfind -name stdlib.h
example:  mdfind "kMDItemAuthor == '*MyFavoriteAuthor*'"
example:  mdfind -live MyFavoriteAuthor
```
```zsh
➜  mdcards git:(master) ✗ mdfind -count downloads
5642
```
love this tool:
```zsh
➜  mdcards git:(master) ✗ mdfind -onlyin $(mdfind Downloads | grep Downloads$ | head -1 ) Bio
/Users/brycesmith/Downloads/232 Aufsatz 2.pdf
/Users/brycesmith/Downloads/Forte Decentralization in Wikipedia Governance 2009.pdf
/Users/brycesmith/Downloads/7 SI 410 2020 MediaWiki Writing Assignment Details.pdf
/Users/brycesmith/Downloads/SI 410 2020 Week 7b MediaWiki Assignment Overview (3).pptx
/Users/brycesmith/Downloads/SI 410 2020 Week 7b MediaWiki Assignment Overview.pptx
/Users/brycesmith/Downloads/SI 410 2020 Week 7b MediaWiki Assignment Overview (1).pptx
/Users/brycesmith/Downloads/Richardson Bentham Self Image 1997.pdf
/Users/brycesmith/Downloads/Forte Decentralization in Wikipedia Governance 2009 (1).pdf
/Users/brycesmith/Downloads/GER232FOTO_FinalProject.docx
/Users/brycesmith/Downloads/GER232FOTO_Fotografenprofil.docx
/Users/brycesmith/Downloads/GER232FOTO_SchreibenII (1).pdf
/Users/brycesmith/Downloads/Thomas Struth Script.pdf
/Users/brycesmith/Downloads/GER232FOTO_SchreibenII.pdf
/Users/brycesmith/Downloads/Moor Why We Need 2005.pdf
/Users/brycesmith/Downloads/Gelernter The Second Coming _ A Manifesto - 19991231.pdf
/Users/brycesmith/Downloads/fun-bio-bryce-smith.pptx
/Users/brycesmith/Downloads/Final Exam Review - F19.pdf
/Users/brycesmith/Downloads/fun-bio-bryce-smith.pdf
/Users/brycesmith/Downloads/Fun Bio Template - University Edition.pptx
/Users/brycesmith/Downloads/GER232FOTO_FinalProject.docx
/Users/brycesmith/Downloads/SI 410 2020 Week 7b MediaWiki Assignment Overview (4).pptx
/Users/brycesmith/Downloads/SI 410 2020 Week 7b MediaWiki Assignment Overview (2).pptx
/Users/brycesmith/Downloads/Turilli Floridi Information Transparency 2009.pdf
/Users/brycesmith/Downloads/GER232Foto_SanderBlossfeldt.pdf
/Users/brycesmith/Downloads/Hill The Eccentric Genius Whose Time May Have Finally Come (Again) 2014.pdf
```
```zsh
➜  mdcards git:(master) ✗ mdfind -literal "kMDItemDisplayName == mdcards.py"
/Users/brycesmith/Files/mdcards/mdcards.py
```
-supposed to be as if we typed in ui:
```zsh
➜  mdcards git:(master) ✗ mdfind -interpret Alfred | head -10
/Users/brycesmith/Library/Application Support/Alfred/Alfred.alfredpreferences
/Users/brycesmith/Library/Application Support/Google/Chrome/Default/Bookmarks
/Users/brycesmith/Library/Application Support/Google/Chrome/Default/Bookmarks.bak
/Users/brycesmith/Library/Application Support/Code/Backups/1591485458248/file/3fc74a8c1134dcd2abc66a8cbb44074c
/Users/brycesmith/Downloads/Swift.Window.Switcher.v0.3.6 (1).alfredworkflow
/Users/brycesmith/Library/Application Support/Alfred/Assistant/Alfred Assistant
/Users/brycesmith/Library/Application Support/Alfred
/Users/brycesmith/Applications/Alfred 4.app
/Applications/Alfred 4.app
/Users/brycesmith/Downloads/Alfred_4.0.9_1144.dmg
```
```
➜  mdcards git:(master) ✗ mdfind Alfred kind:application
/Users/brycesmith/Applications/Alfred 4.app
/Applications/Alfred 4.app
```
valid kinds:
```
Applications kind:application, kind:applications, kind:app
Audio/Music kind:audio, kind:music
Bookmarks kind:bookmark, kind:bookmarks
Contacts kind:contact, kind:contacts
Email kind:email, kind:emails, kind:mail message, kind:mail messages
Folders kind:folder, kind:folders
Fonts kind:font, kind:fonts
iCal Events kind:event, kind:events
iCal To Dos kind:todo, kind:todos, kind:to do, kind:to dos
Images kind:image, kind:images
Movies kind:movie, kind:movies
PDF kind:pdf, kind:pdfs
Preferences kind:system preferences, kind:preferences
Presentations kind:presentations, kind:presentation
```
valid dates:
```
date:today    $time.today()
date:yesterday .yesterday()
date:this week  .this_week()
date:this month .this_month()
date:this year  .this_year()

date:tomorrow  .tomorrow()
date:next month  .next_month()
date:next week  .next_week()
date:next year  .next_year()
```

```
By default mdfind will AND together elements of the query string.
| (OR) To return items that match either word, use the pipe character: stringA|stringB
- (NOT) To exclude documents that match a string -string
= “equal”
== “equal”
!= “not equal”
< and > “less” or “more than”
<= and >= “less than or equal” or “more than or equal”
InRange(attributeName,minValue,maxValue) Numeric values within the range of minValue to maxValue in the specified attribute.

Whitespace is significant when building a query, use parentheses () to create groups.
Characters such as “ and ‘ in the value string should be escaped using the \ character
```


case:
```
Modifier	Description
c	The comparison is case insensitive.
d	The comparison is insensitive to diacritical marks.
```
