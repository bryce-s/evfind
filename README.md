# evfind

# FAQ
-What does this even mean:
> A Unix I/O compliant Windows reimplementation of Mac OS's mdfind tool

* It means I often want to use `mdfind` in `Windows Subsystem Linux` or `Git Bash`. Sadly, `mdfind` is a Mac OS specific tool. There are no good bash-compliant system indexers avaliable for Windows. So--we reimplement `mdfind`.

-Why isn't locate a good alternative?
* Running `updatedb` is slow and annoying, I often want to find files with search indexing.
