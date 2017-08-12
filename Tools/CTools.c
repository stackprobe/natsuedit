#include "C:\Factory\Common\all.h"
#include "C:\Factory\Common\Options\FileTools.h"
#include "C:\Factory\SubTools\libs\wavFile.h"

static void DoCutFile(char *file, uint64 startPos, uint64 endPos)
{
	uint64 size = getFileSize(file);

	LOGPOS();

	cout("file: %s\n", file);
	cout("range: %I64u, %I64u\n", startPos, endPos);

	if(endPos < size)
	{
		LOGPOS();
		DeleteFileDataPart(file, startPos, endPos - startPos);
		LOGPOS();
	}
	else
	{
		LOGPOS();
		setFileSize(file, startPos);
		LOGPOS();
	}
	LOGPOS();
}
static void Main2(void)
{
	if(argIs("/W2C"))
	{
		char *rFile;
		char *wFile;
		char *wHzFile;

		rFile = nextArg();
		wFile = nextArg();
		wHzFile = nextArg();

		LOGPOS();
		readWAVFileToCSVFile(rFile, wFile);
		LOGPOS();
		writeOneLineNoRet_b_cx(wHzFile, xcout("%u", lastWAV_Hz));
		LOGPOS();
		return;
	}
	if(argIs("/C2W"))
	{
		char *rFile;
		char *wFile;
		uint hz;

		rFile = nextArg();
		wFile = nextArg();
		hz = toValue(nextArg());

		LOGPOS();
		writeWAVFileFromCSVFile(rFile, wFile, hz);
		LOGPOS();
		return;
	}
	if(argIs("/FCUT"))
	{
		char *file;
		uint64 startPos;
		uint64 endPos;

		file = nextArg();
		startPos = toValue64(nextArg()); // ここから
		endPos   = toValue64(nextArg()); // この直前までをカットする。

		errorCase(endPos < startPos);

		LOGPOS();
		DoCutFile(file, startPos, endPos);
		LOGPOS();
		return;
	}
	error();
}
int main(int argc, char **argv)
{
	LOGPOS();
	Main2();
	LOGPOS();
	termination(0);
}
