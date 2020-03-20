IF NOT EXIST natsuedit\. GOTO END
CLS
rem リリースして qrum します。
PAUSE

CALL ff
cx **

CD /D %~dp0.

IF NOT EXIST natsuedit\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\natsuedit.zip S:\リリース物\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END
