/// <binding ProjectOpened='default, watch' />
var gulp = require('gulp');
var del = require('del');
var $ = require('gulp-load-plugins')({ lazy: false });

var config = {
    less: {
        src: [
            './styles/bootstrap-custom.less',
            './styles/animated-links.less',
            './styles/header-animations.less',
            './node_modules/font-awesome/less/font-awesome.less'
        ],
        dest: './wwwroot/css'
    },
    npm: {
        fontAwesome: { src: './node_modules/font-awesome/fonts/*', dest: './wwwroot/fonts' }
    }
};

gulp.task('default', ['less', 'copy']);

gulp.task('watch', function () {
    gulp.watch(config.less.src, ['less']);
});

gulp.task('less', function() {
    return gulp.src(config.less.src)
        .pipe($.plumber({ errorHandler: errorHandler }))
        .pipe($.sourcemaps.init())
        .pipe($.less())
        .pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe($.minifyCss())
        .pipe($.concat('all.min.css'))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(config.less.dest));
});

gulp.task('copy', function() {
    for (var pkg in config.npm) {
        if (!config.npm.hasOwnProperty(pkg)) continue;

        gulp.src(config.npm[pkg].src)
            .pipe(gulp.dest(config.npm[pkg].dest));
    }
});


///////////////////////////////////
//END OF GULP TASKS
///////////////////////////////////

function log(msg, color) {
    color = color || 'blue';
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors[color](msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors[color](msg));
    }
}

function errorHandler(err) {
    log(err.message, 'red');
    this.emit('end');
}
