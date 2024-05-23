# -*- coding:utf-8 -*-

from wxpy import *
from platform import system
from os.path import exists
from os import makedirs
from os import listdir
from shutil import rmtree
from queue import Queue
from threading import Thread
from time import sleep
from pyecharts.charts import Pie
from pyecharts.charts import Map
from pyecharts.charts import WordCloud
from pyecharts.charts import Bar
from pyecharts import options as opts
from requests import post
import PIL.Image as Image
import re
import random
import math
from cv2 import CascadeClassifier
from cv2 import imread
from cv2 import cvtColor
from cv2 import COLOR_BGR2GRAY


# 引入打开文件所用的库
# Window与Linux和Mac OSX有所不同
# lambda用来定义一个匿名函数，可实现类似c语言的define定义
if('Windows' in system()):
    # Windows
    from os import startfile
    open_html = lambda x : startfile(x)
elif('Darwin' in system()):
    # MacOSX
    from subprocess import call
    open_html = lambda x : call(["open", x])
else:
    # Linux
    from subprocess import call
    open_html = lambda x: call(["xdg-open", x])


# 分析好友性别比例
def sex_ratio():

    # 初始化
    male, female, other = 0, 0, 0

    # 遍历
    for user in friends:
        if(user.sex == 1):
            male += 1
        elif(user.sex == 2):
            female += 1
        else:
            other += 1

    name_list = ['男性', '女性', '未设置']
    num_list = [male, female, other]

    pie = Pie()
    pie.add("微信好友性别比例", [list(z) for z in zip(name_list, num_list)])
    pie.set_global_opts(title_opts=opts.TitleOpts(title="微信好友性别比例"))
    pie.set_series_opts(label_opts=opts.LabelOpts(formatter="{b}: {c}"))
    pie.render('data/好友性别比例.html')
