
This application is used to maintain contest results, the season points race,
and the historical pilot statistics seen on the [Canadian Prairie Pylon Racing Association](http://cppra.org) website. 

It could be used by other racing clubs that want to show contest results 
and track pilot points.


# Importing Data
## Pilots
* File format is CSV with 1-3 fields.
    * Field 1: Pilot Name
    * Field 2: Pilot Number
    * Field 3: Active indicator. May be 'yes' or 'no'.

Example file pilots.csv:
```
Kevin Umbach,32x,yes
Allan Umbach,31x,yes
```
* Do not include column headers.
* Column 1 is required, the others are optional.
* If 'active' column is not specified, default value is 'yes'.

## Contests
* File format is CSV with a specially formatted contest header record.

Example file contests.csv:
```
2020-07-01,Q500 (AMA 426),Saskatoon
1,Kevin Umbach,nt,nt,nt,nt,nt,nt,nt,nt
2,Bob Hover,nt,nt,nt,nt,nt,nt,nt,nt

2020-07-02,Q40 (AMA 422),Saskatoon
1,Kevin Umbach,nt,nt,nt,nt,nt,nt,nt,nt
2,Bob Hover,nt,nt,nt,nt,nt,nt,nt,nt
```
* Do not include any column headers.
* Leave a blank line between contests.
* Ensure each pilot row in a contest has the same number of heats.



