            updateById(index, row) {
                this.brand.id = row.id;
                this.centerVisible = true;
            },
            //修改数据的部分内容
            edit() {
                var _this = this;
                //发送ajax异步请求，添加数据
                axios({
                    method: "post",
                    url: "http://localhost:8080/brand-case/brand/updateById",
                    data: _this.brand
                }).then(function (resp) {
                    if (resp.data == "success") {
                        //关闭窗口
                        _this.centerVisible = false;
                        //查询一次
                        _this.selectAll();
                        _this.$message({
                            message: '恭喜你，修改数据成功',
                            type: 'success'
                        });
                    } else {
                        _this.$message.error('修改数据失败');
                    }
                })
            },

