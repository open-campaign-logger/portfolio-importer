// Copyright 2017 Jochen Linnemann
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

/// <binding BeforeBuild='beforeBuild' />
module.exports = function(grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        copy: {
            jQuery: {
                files: [
                    {
                        expand: true,
                        cwd: 'node_modules/jQuery/dist',
                        src: '**',
                        dest: 'wwwroot/js/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery-validation/dist',
                        src: '*.js',
                        dest: 'wwwroot/js/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery-validation-unobtrusive',
                        src: 'jquery.validate.unobtrusive.js',
                        dest: 'wwwroot/js/'
                    }
                ]
            },
            bootstrap: {
                files: [
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap-sass/assets/fonts',
                        src: '**',
                        dest: 'wwwroot/fonts/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap-sass/assets/javascripts',
                        src: ['bootstrap.js', 'bootstrap.min.js'],
                        dest: 'wwwroot/js/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap-dialog/dist/css',
                        src: ['bootstrap-dialog.css', 'bootstrap-dialog.min.css'],
                        dest: 'wwwroot/css/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap-dialog/dist/js',
                        src: ['bootstrap-dialog.js', 'bootstrap-dialog.min.js'],
                        dest: 'wwwroot/js/'
                    }
                ]
            }
        },
        sass: {
            'wwwroot/css/filehandler.css': ['wwwroot/css/filehandler.scss']
        },
        subgrunt: {
            bootswatch: {
                options: {
                    passGruntFlags: false
                },
                projects: {
                    'node_modules/bootswatch-sass': 'default'
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-subgrunt');

    grunt.registerTask('default', ['copy:jQuery', 'copy:bootstrap']);
    grunt.registerTask('default-sass', ['default', 'sass']);
    grunt.registerTask('full', ['subgrunt:bootswatch', 'default']);
    grunt.registerTask('beforeBuild', ['default']);
};