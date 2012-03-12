import fileinput
import re
import argparse

lines2 = []

def process_slide(line):
	global args, lines2
	print "line?", line
	a = re.search("([ \t]*)(.*?)([\t ]*)=([\t ]*)(\d+)(.*)", line)
	if (a == None):
		print "skiped: ",line
		lines2.append(line)
		return
	num = int(a.group(5))
	if (int(a.group(5)) >= args.offset):
		num += args.addend
	print a.group(2), str(num), a.group(6)
	lines2.append(a.group(1)+a.group(2)+a.group(3)+"="+a.group(4)+str(num)+a.group(6))
	
parser = argparse.ArgumentParser(description='opcodes')
parser.add_argument('offset', metavar='Offset', type=int,
                   help='starting offset')
				   
parser.add_argument('addend', metavar='Add', type=int,
					default=0,
                   help='slide amount')
				   
args = parser.parse_args()

print "offset:", args.offset
print "addend:", args.addend

process = process_slide

a = file("oldopcodes.txt")
lines = a.readlines()
for line in lines:
    process(line)
a.close()

a = file("oldopcodes.txt", "w")
for line in lines2:
	a.write(line+"\n")
	#print line
a.close()
