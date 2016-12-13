var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_1) {
        var Movie;
        (function (Movie) {
            var VideoDialog = (function (_super) {
                __extends(VideoDialog, _super);
                function VideoDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.VideoForm(this.idPrefix);
                }
                VideoDialog.prototype.getFormKey = function () { return Movie.VideoForm.formKey; };
                VideoDialog.prototype.getIdProperty = function () { return Movie.VideoRow.idProperty; };
                VideoDialog.prototype.getLocalTextPrefix = function () { return Movie.VideoRow.localTextPrefix; };
                VideoDialog.prototype.getNameProperty = function () { return Movie.VideoRow.nameProperty; };
                VideoDialog.prototype.getService = function () { return Movie.VideoService.baseUrl; };
                VideoDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], VideoDialog);
                return VideoDialog;
            }(Serenity.EntityDialog));
            Movie.VideoDialog = VideoDialog;
        })(Movie = Movie_1.Movie || (Movie_1.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var GridEditorBase = (function (_super) {
                __extends(GridEditorBase, _super);
                function GridEditorBase(container) {
                    _super.call(this, container);
                    this.nextId = 1;
                }
                GridEditorBase.prototype.getIdProperty = function () { return "__id"; };
                GridEditorBase.prototype.id = function (entity) {
                    return entity.__id;
                };
                GridEditorBase.prototype.save = function (opt, callback) {
                    var _this = this;
                    var request = opt.request;
                    var row = Q.deepClone(request.Entity);
                    var id = row.__id;
                    if (id == null) {
                        row.__id = this.nextId++;
                    }
                    if (!this.validateEntity(row, id)) {
                        return;
                    }
                    var items = this.view.getItems().slice();
                    if (id == null) {
                        items.push(row);
                    }
                    else {
                        var index = Q.indexOf(items, function (x) { return _this.id(x) === id; });
                        items[index] = Q.deepClone({}, items[index], row);
                    }
                    this.setEntities(items);
                    callback({});
                };
                GridEditorBase.prototype.deleteEntity = function (id) {
                    this.view.deleteItem(id);
                    return true;
                };
                GridEditorBase.prototype.validateEntity = function (row, id) {
                    return true;
                };
                GridEditorBase.prototype.setEntities = function (items) {
                    this.view.setItems(items, true);
                };
                GridEditorBase.prototype.getNewEntity = function () {
                    return {};
                };
                GridEditorBase.prototype.getButtons = function () {
                    var _this = this;
                    return [{
                            title: this.getAddButtonCaption(),
                            cssClass: 'add-button',
                            onClick: function () {
                                _this.createEntityDialog(_this.getItemType(), function (dlg) {
                                    var dialog = dlg;
                                    dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                                    dialog.loadEntityAndOpenDialog(_this.getNewEntity());
                                });
                            }
                        }];
                };
                GridEditorBase.prototype.editItem = function (entityOrId) {
                    var _this = this;
                    var id = entityOrId;
                    var item = this.view.getItemById(id);
                    this.createEntityDialog(this.getItemType(), function (dlg) {
                        var dialog = dlg;
                        dialog.onDelete = function (opt, callback) {
                            if (!_this.deleteEntity(id)) {
                                return;
                            }
                            callback({});
                        };
                        dialog.onSave = function (opt, callback) { return _this.save(opt, callback); };
                        dialog.loadEntityAndOpenDialog(item);
                    });
                    ;
                };
                GridEditorBase.prototype.getEditValue = function (property, target) {
                    target[property.name] = this.value;
                };
                GridEditorBase.prototype.setEditValue = function (source, property) {
                    this.value = source[property.name];
                };
                Object.defineProperty(GridEditorBase.prototype, "value", {
                    get: function () {
                        return this.view.getItems().map(function (x) {
                            var y = Q.deepClone(x);
                            delete y['__id'];
                            return y;
                        });
                    },
                    set: function (value) {
                        var _this = this;
                        this.view.setItems((value || []).map(function (x) {
                            var y = Q.deepClone(x);
                            y.__id = _this.nextId++;
                            return y;
                        }), true);
                    },
                    enumerable: true,
                    configurable: true
                });
                GridEditorBase.prototype.getGridCanLoad = function () {
                    return false;
                };
                GridEditorBase.prototype.usePager = function () {
                    return false;
                };
                GridEditorBase.prototype.getInitialTitle = function () {
                    return null;
                };
                GridEditorBase.prototype.createQuickSearchInput = function () {
                };
                GridEditorBase = __decorate([
                    Serenity.Decorators.registerClass([Serenity.IGetEditValue, Serenity.ISetEditValue]),
                    Serenity.Decorators.editor(),
                    Serenity.Decorators.element("<div/>")
                ], GridEditorBase);
                return GridEditorBase;
            }(Serenity.EntityGrid));
            Common.GridEditorBase = GridEditorBase;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_2) {
        var Movie;
        (function (Movie) {
            var VideoEditor = (function (_super) {
                __extends(VideoEditor, _super);
                function VideoEditor(container) {
                    _super.call(this, container);
                }
                VideoEditor.prototype.getColumnsKey = function () { return 'Movie.Video'; };
                VideoEditor.prototype.getDialogType = function () { return Movie.VideoEditorDialog; };
                VideoEditor.prototype.getLocalTextPrefix = function () { return Movie.VideoRow.localTextPrefix; };
                VideoEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], VideoEditor);
                return VideoEditor;
            }(Movie_2.Common.GridEditorBase));
            Movie.VideoEditor = VideoEditor;
        })(Movie = Movie_2.Movie || (Movie_2.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var GridEditorDialog = (function (_super) {
                __extends(GridEditorDialog, _super);
                function GridEditorDialog() {
                    _super.apply(this, arguments);
                }
                GridEditorDialog.prototype.getIdProperty = function () { return "__id"; };
                GridEditorDialog.prototype.destroy = function () {
                    this.onSave = null;
                    this.onDelete = null;
                    _super.prototype.destroy.call(this);
                };
                GridEditorDialog.prototype.updateInterface = function () {
                    _super.prototype.updateInterface.call(this);
                    // apply changes button doesn't work properly with in-memory grids yet
                    if (this.applyChangesButton) {
                        this.applyChangesButton.hide();
                    }
                };
                GridEditorDialog.prototype.saveHandler = function (options, callback) {
                    this.onSave && this.onSave(options, callback);
                };
                GridEditorDialog.prototype.deleteHandler = function (options, callback) {
                    this.onDelete && this.onDelete(options, callback);
                };
                GridEditorDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], GridEditorDialog);
                return GridEditorDialog;
            }(Serenity.EntityDialog));
            Common.GridEditorDialog = GridEditorDialog;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_3) {
        var Movie;
        (function (Movie) {
            var VideoEditorDialog = (function (_super) {
                __extends(VideoEditorDialog, _super);
                function VideoEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.VideoForm(this.idPrefix);
                }
                VideoEditorDialog.prototype.getFormKey = function () { return Movie.VideoForm.formKey; };
                VideoEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.VideoRow.localTextPrefix; };
                VideoEditorDialog.prototype.getNameProperty = function () { return Movie.VideoRow.nameProperty; };
                VideoEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], VideoEditorDialog);
                return VideoEditorDialog;
            }(Movie_3.Common.GridEditorDialog));
            Movie.VideoEditorDialog = VideoEditorDialog;
        })(Movie = Movie_3.Movie || (Movie_3.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_4) {
        var Movie;
        (function (Movie) {
            var VideoGrid = (function (_super) {
                __extends(VideoGrid, _super);
                function VideoGrid(container) {
                    _super.call(this, container);
                }
                VideoGrid.prototype.getColumnsKey = function () { return 'Movie.Video'; };
                VideoGrid.prototype.getDialogType = function () { return Movie.VideoDialog; };
                VideoGrid.prototype.getIdProperty = function () { return Movie.VideoRow.idProperty; };
                VideoGrid.prototype.getLocalTextPrefix = function () { return Movie.VideoRow.localTextPrefix; };
                VideoGrid.prototype.getService = function () { return Movie.VideoService.baseUrl; };
                VideoGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], VideoGrid);
                return VideoGrid;
            }(Serenity.EntityGrid));
            Movie.VideoGrid = VideoGrid;
        })(Movie = Movie_4.Movie || (Movie_4.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_5) {
        var Movie;
        (function (Movie) {
            var TagDialog = (function (_super) {
                __extends(TagDialog, _super);
                function TagDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.TagForm(this.idPrefix);
                }
                TagDialog.prototype.getFormKey = function () { return Movie.TagForm.formKey; };
                TagDialog.prototype.getIdProperty = function () { return Movie.TagRow.idProperty; };
                TagDialog.prototype.getLocalTextPrefix = function () { return Movie.TagRow.localTextPrefix; };
                TagDialog.prototype.getNameProperty = function () { return Movie.TagRow.nameProperty; };
                TagDialog.prototype.getService = function () { return Movie.TagService.baseUrl; };
                TagDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], TagDialog);
                return TagDialog;
            }(Serenity.EntityDialog));
            Movie.TagDialog = TagDialog;
        })(Movie = Movie_5.Movie || (Movie_5.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_6) {
        var Movie;
        (function (Movie) {
            var TagEditor = (function (_super) {
                __extends(TagEditor, _super);
                function TagEditor(container) {
                    _super.call(this, container);
                }
                TagEditor.prototype.getColumnsKey = function () { return 'Movie.Tag'; };
                TagEditor.prototype.getDialogType = function () { return Movie.TagEditorDialog; };
                TagEditor.prototype.getLocalTextPrefix = function () { return Movie.TagRow.localTextPrefix; };
                TagEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], TagEditor);
                return TagEditor;
            }(Movie_6.Common.GridEditorBase));
            Movie.TagEditor = TagEditor;
        })(Movie = Movie_6.Movie || (Movie_6.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_7) {
        var Movie;
        (function (Movie) {
            var TagEditorDialog = (function (_super) {
                __extends(TagEditorDialog, _super);
                function TagEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.TagForm(this.idPrefix);
                }
                TagEditorDialog.prototype.getFormKey = function () { return Movie.TagForm.formKey; };
                TagEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.TagRow.localTextPrefix; };
                TagEditorDialog.prototype.getNameProperty = function () { return Movie.TagRow.nameProperty; };
                TagEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], TagEditorDialog);
                return TagEditorDialog;
            }(Movie_7.Common.GridEditorDialog));
            Movie.TagEditorDialog = TagEditorDialog;
        })(Movie = Movie_7.Movie || (Movie_7.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_8) {
        var Movie;
        (function (Movie) {
            var TagGrid = (function (_super) {
                __extends(TagGrid, _super);
                function TagGrid(container) {
                    _super.call(this, container);
                }
                TagGrid.prototype.getColumnsKey = function () { return 'Movie.Tag'; };
                TagGrid.prototype.getDialogType = function () { return Movie.TagDialog; };
                TagGrid.prototype.getIdProperty = function () { return Movie.TagRow.idProperty; };
                TagGrid.prototype.getLocalTextPrefix = function () { return Movie.TagRow.localTextPrefix; };
                TagGrid.prototype.getService = function () { return Movie.TagService.baseUrl; };
                TagGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], TagGrid);
                return TagGrid;
            }(Serenity.EntityGrid));
            Movie.TagGrid = TagGrid;
        })(Movie = Movie_8.Movie || (Movie_8.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_9) {
        var Movie;
        (function (Movie) {
            var ServiceRatingDialog = (function (_super) {
                __extends(ServiceRatingDialog, _super);
                function ServiceRatingDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServiceRatingForm(this.idPrefix);
                }
                ServiceRatingDialog.prototype.getFormKey = function () { return Movie.ServiceRatingForm.formKey; };
                ServiceRatingDialog.prototype.getIdProperty = function () { return Movie.ServiceRatingRow.idProperty; };
                ServiceRatingDialog.prototype.getLocalTextPrefix = function () { return Movie.ServiceRatingRow.localTextPrefix; };
                ServiceRatingDialog.prototype.getService = function () { return Movie.ServiceRatingService.baseUrl; };
                ServiceRatingDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServiceRatingDialog);
                return ServiceRatingDialog;
            }(Serenity.EntityDialog));
            Movie.ServiceRatingDialog = ServiceRatingDialog;
        })(Movie = Movie_9.Movie || (Movie_9.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_10) {
        var Movie;
        (function (Movie) {
            var ServiceRatingEditor = (function (_super) {
                __extends(ServiceRatingEditor, _super);
                function ServiceRatingEditor(container) {
                    _super.call(this, container);
                }
                ServiceRatingEditor.prototype.getColumnsKey = function () { return 'Movie.ServiceRating'; };
                ServiceRatingEditor.prototype.getDialogType = function () { return Movie.ServiceRatingEditorDialog; };
                ServiceRatingEditor.prototype.getLocalTextPrefix = function () { return Movie.ServiceRatingRow.localTextPrefix; };
                ServiceRatingEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServiceRatingEditor);
                return ServiceRatingEditor;
            }(Movie_10.Common.GridEditorBase));
            Movie.ServiceRatingEditor = ServiceRatingEditor;
        })(Movie = Movie_10.Movie || (Movie_10.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_11) {
        var Movie;
        (function (Movie) {
            var ServiceRatingEditorDialog = (function (_super) {
                __extends(ServiceRatingEditorDialog, _super);
                function ServiceRatingEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServiceRatingForm(this.idPrefix);
                }
                ServiceRatingEditorDialog.prototype.getFormKey = function () { return Movie.ServiceRatingForm.formKey; };
                ServiceRatingEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.ServiceRatingRow.localTextPrefix; };
                ServiceRatingEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServiceRatingEditorDialog);
                return ServiceRatingEditorDialog;
            }(Movie_11.Common.GridEditorDialog));
            Movie.ServiceRatingEditorDialog = ServiceRatingEditorDialog;
        })(Movie = Movie_11.Movie || (Movie_11.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_12) {
        var Movie;
        (function (Movie) {
            var ServiceRatingGrid = (function (_super) {
                __extends(ServiceRatingGrid, _super);
                function ServiceRatingGrid(container) {
                    _super.call(this, container);
                }
                ServiceRatingGrid.prototype.getColumnsKey = function () { return 'Movie.ServiceRating'; };
                ServiceRatingGrid.prototype.getDialogType = function () { return Movie.ServiceRatingDialog; };
                ServiceRatingGrid.prototype.getIdProperty = function () { return Movie.ServiceRatingRow.idProperty; };
                ServiceRatingGrid.prototype.getLocalTextPrefix = function () { return Movie.ServiceRatingRow.localTextPrefix; };
                ServiceRatingGrid.prototype.getService = function () { return Movie.ServiceRatingService.baseUrl; };
                ServiceRatingGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServiceRatingGrid);
                return ServiceRatingGrid;
            }(Serenity.EntityGrid));
            Movie.ServiceRatingGrid = ServiceRatingGrid;
        })(Movie = Movie_12.Movie || (Movie_12.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_13) {
        var Movie;
        (function (Movie) {
            var ServicePathDialog = (function (_super) {
                __extends(ServicePathDialog, _super);
                function ServicePathDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServicePathForm(this.idPrefix);
                }
                ServicePathDialog.prototype.getFormKey = function () { return Movie.ServicePathForm.formKey; };
                ServicePathDialog.prototype.getIdProperty = function () { return Movie.ServicePathRow.idProperty; };
                ServicePathDialog.prototype.getLocalTextPrefix = function () { return Movie.ServicePathRow.localTextPrefix; };
                ServicePathDialog.prototype.getNameProperty = function () { return Movie.ServicePathRow.nameProperty; };
                ServicePathDialog.prototype.getService = function () { return Movie.ServicePathService.baseUrl; };
                ServicePathDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServicePathDialog);
                return ServicePathDialog;
            }(Serenity.EntityDialog));
            Movie.ServicePathDialog = ServicePathDialog;
        })(Movie = Movie_13.Movie || (Movie_13.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_14) {
        var Movie;
        (function (Movie) {
            var ServicePathEditor = (function (_super) {
                __extends(ServicePathEditor, _super);
                function ServicePathEditor(container) {
                    _super.call(this, container);
                }
                ServicePathEditor.prototype.getColumnsKey = function () { return 'Movie.ServicePath'; };
                ServicePathEditor.prototype.getDialogType = function () { return Movie.ServicePathEditorDialog; };
                ServicePathEditor.prototype.getLocalTextPrefix = function () { return Movie.ServicePathRow.localTextPrefix; };
                ServicePathEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServicePathEditor);
                return ServicePathEditor;
            }(Movie_14.Common.GridEditorBase));
            Movie.ServicePathEditor = ServicePathEditor;
        })(Movie = Movie_14.Movie || (Movie_14.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_15) {
        var Movie;
        (function (Movie) {
            var ServicePathEditorDialog = (function (_super) {
                __extends(ServicePathEditorDialog, _super);
                function ServicePathEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServicePathForm(this.idPrefix);
                }
                ServicePathEditorDialog.prototype.getFormKey = function () { return Movie.ServicePathForm.formKey; };
                ServicePathEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.ServicePathRow.localTextPrefix; };
                ServicePathEditorDialog.prototype.getNameProperty = function () { return Movie.ServicePathRow.nameProperty; };
                ServicePathEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServicePathEditorDialog);
                return ServicePathEditorDialog;
            }(Movie_15.Common.GridEditorDialog));
            Movie.ServicePathEditorDialog = ServicePathEditorDialog;
        })(Movie = Movie_15.Movie || (Movie_15.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_16) {
        var Movie;
        (function (Movie) {
            var ServicePathGrid = (function (_super) {
                __extends(ServicePathGrid, _super);
                function ServicePathGrid(container) {
                    _super.call(this, container);
                }
                ServicePathGrid.prototype.getColumnsKey = function () { return 'Movie.ServicePath'; };
                ServicePathGrid.prototype.getDialogType = function () { return Movie.ServicePathDialog; };
                ServicePathGrid.prototype.getIdProperty = function () { return Movie.ServicePathRow.idProperty; };
                ServicePathGrid.prototype.getLocalTextPrefix = function () { return Movie.ServicePathRow.localTextPrefix; };
                ServicePathGrid.prototype.getService = function () { return Movie.ServicePathService.baseUrl; };
                ServicePathGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServicePathGrid);
                return ServicePathGrid;
            }(Serenity.EntityGrid));
            Movie.ServicePathGrid = ServicePathGrid;
        })(Movie = Movie_16.Movie || (Movie_16.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_17) {
        var Movie;
        (function (Movie) {
            var ServiceDialog = (function (_super) {
                __extends(ServiceDialog, _super);
                function ServiceDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServiceForm(this.idPrefix);
                }
                ServiceDialog.prototype.getFormKey = function () { return Movie.ServiceForm.formKey; };
                ServiceDialog.prototype.getIdProperty = function () { return Movie.ServiceRow.idProperty; };
                ServiceDialog.prototype.getLocalTextPrefix = function () { return Movie.ServiceRow.localTextPrefix; };
                ServiceDialog.prototype.getNameProperty = function () { return Movie.ServiceRow.nameProperty; };
                ServiceDialog.prototype.getService = function () { return Movie.ServiceService.baseUrl; };
                ServiceDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServiceDialog);
                return ServiceDialog;
            }(Serenity.EntityDialog));
            Movie.ServiceDialog = ServiceDialog;
        })(Movie = Movie_17.Movie || (Movie_17.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_18) {
        var Movie;
        (function (Movie) {
            var ServiceEditor = (function (_super) {
                __extends(ServiceEditor, _super);
                function ServiceEditor(container) {
                    _super.call(this, container);
                }
                ServiceEditor.prototype.getColumnsKey = function () { return 'Movie.Service'; };
                ServiceEditor.prototype.getDialogType = function () { return Movie.ServiceEditorDialog; };
                ServiceEditor.prototype.getLocalTextPrefix = function () { return Movie.ServiceRow.localTextPrefix; };
                ServiceEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServiceEditor);
                return ServiceEditor;
            }(Movie_18.Common.GridEditorBase));
            Movie.ServiceEditor = ServiceEditor;
        })(Movie = Movie_18.Movie || (Movie_18.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_19) {
        var Movie;
        (function (Movie) {
            var ServiceEditorDialog = (function (_super) {
                __extends(ServiceEditorDialog, _super);
                function ServiceEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.ServiceForm(this.idPrefix);
                }
                ServiceEditorDialog.prototype.getFormKey = function () { return Movie.ServiceForm.formKey; };
                ServiceEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.ServiceRow.localTextPrefix; };
                ServiceEditorDialog.prototype.getNameProperty = function () { return Movie.ServiceRow.nameProperty; };
                ServiceEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], ServiceEditorDialog);
                return ServiceEditorDialog;
            }(Movie_19.Common.GridEditorDialog));
            Movie.ServiceEditorDialog = ServiceEditorDialog;
        })(Movie = Movie_19.Movie || (Movie_19.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_20) {
        var Movie;
        (function (Movie) {
            var ServiceGrid = (function (_super) {
                __extends(ServiceGrid, _super);
                function ServiceGrid(container) {
                    _super.call(this, container);
                }
                ServiceGrid.prototype.getColumnsKey = function () { return 'Movie.Service'; };
                ServiceGrid.prototype.getDialogType = function () { return Movie.ServiceDialog; };
                ServiceGrid.prototype.getIdProperty = function () { return Movie.ServiceRow.idProperty; };
                ServiceGrid.prototype.getLocalTextPrefix = function () { return Movie.ServiceRow.localTextPrefix; };
                ServiceGrid.prototype.getService = function () { return Movie.ServiceService.baseUrl; };
                ServiceGrid.prototype.getColumns = function () {
                    var columns = _super.prototype.getColumns.call(this);
                    var fld = Movie.ServiceRow.Fields;
                    Q.first(columns, function (x) { return x.field == fld.Api; }).format =
                        function (ctx) { return ("<a href=\"javascript:;\" class=\"btn btn-info\">" + Q.htmlEncode(ctx.value) + "</a>"); };
                    return columns;
                };
                ServiceGrid.prototype.onClick = function (e, row, cell) {
                    // let base grid handle clicks for its edit links
                    _super.prototype.onClick.call(this, e, row, cell);
                    // if base grid already handled, we shouldn"t handle it again
                    if (e.isDefaultPrevented()) {
                        return;
                    }
                    // get reference to current item
                    var item = this.itemAt(row);
                    // get reference to clicked element
                    var target = $(e.target);
                    if (target.hasClass("btn-info")) {
                        e.preventDefault();
                        console.log("click");
                        var data = Q.serviceCall({
                            service: '/Movie/Service/GetMovies?id=' + item.ServiceId,
                        }).done(function (data) {
                            if (data != null) {
                                var message = Q.format("<p>No data</p>" + data, Q.htmlEncode(item.Name));
                                Q.confirm(message, function () {
                                }, {
                                    htmlEncode: false,
                                });
                            }
                            else {
                                var message = Q.format("<p>No data</p>", Q.htmlEncode(item.Name));
                                Q.confirm(message, function () {
                                }, {
                                    htmlEncode: false,
                                });
                            }
                        });
                    }
                };
                ServiceGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], ServiceGrid);
                return ServiceGrid;
            }(Serenity.EntityGrid));
            Movie.ServiceGrid = ServiceGrid;
        })(Movie = Movie_20.Movie || (Movie_20.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_21) {
        var Movie;
        (function (Movie) {
            var PersonDialog = (function (_super) {
                __extends(PersonDialog, _super);
                function PersonDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.PersonForm(this.idPrefix);
                }
                PersonDialog.prototype.getFormKey = function () { return Movie.PersonForm.formKey; };
                PersonDialog.prototype.getIdProperty = function () { return Movie.PersonRow.idProperty; };
                PersonDialog.prototype.getLocalTextPrefix = function () { return Movie.PersonRow.localTextPrefix; };
                PersonDialog.prototype.getNameProperty = function () { return Movie.PersonRow.nameProperty; };
                PersonDialog.prototype.getService = function () { return Movie.PersonService.baseUrl; };
                PersonDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], PersonDialog);
                return PersonDialog;
            }(Serenity.EntityDialog));
            Movie.PersonDialog = PersonDialog;
        })(Movie = Movie_21.Movie || (Movie_21.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_22) {
        var Movie;
        (function (Movie) {
            var PersonEditor = (function (_super) {
                __extends(PersonEditor, _super);
                function PersonEditor(container) {
                    _super.call(this, container);
                }
                PersonEditor.prototype.getColumnsKey = function () { return 'Movie.Person'; };
                PersonEditor.prototype.getDialogType = function () { return Movie.PersonEditorDialog; };
                PersonEditor.prototype.getLocalTextPrefix = function () { return Movie.PersonRow.localTextPrefix; };
                PersonEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], PersonEditor);
                return PersonEditor;
            }(Movie_22.Common.GridEditorBase));
            Movie.PersonEditor = PersonEditor;
        })(Movie = Movie_22.Movie || (Movie_22.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_23) {
        var Movie;
        (function (Movie) {
            var PersonEditorDialog = (function (_super) {
                __extends(PersonEditorDialog, _super);
                function PersonEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.PersonForm(this.idPrefix);
                }
                PersonEditorDialog.prototype.getFormKey = function () { return Movie.PersonForm.formKey; };
                PersonEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.PersonRow.localTextPrefix; };
                PersonEditorDialog.prototype.getNameProperty = function () { return Movie.PersonRow.nameProperty; };
                PersonEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], PersonEditorDialog);
                return PersonEditorDialog;
            }(Movie_23.Common.GridEditorDialog));
            Movie.PersonEditorDialog = PersonEditorDialog;
        })(Movie = Movie_23.Movie || (Movie_23.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_24) {
        var Movie;
        (function (Movie) {
            var PersonGrid = (function (_super) {
                __extends(PersonGrid, _super);
                function PersonGrid(container) {
                    _super.call(this, container);
                }
                PersonGrid.prototype.getColumnsKey = function () { return 'Movie.Person'; };
                PersonGrid.prototype.getDialogType = function () { return Movie.PersonDialog; };
                PersonGrid.prototype.getIdProperty = function () { return Movie.PersonRow.idProperty; };
                PersonGrid.prototype.getLocalTextPrefix = function () { return Movie.PersonRow.localTextPrefix; };
                PersonGrid.prototype.getService = function () { return Movie.PersonService.baseUrl; };
                PersonGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], PersonGrid);
                return PersonGrid;
            }(Serenity.EntityGrid));
            Movie.PersonGrid = PersonGrid;
        })(Movie = Movie_24.Movie || (Movie_24.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_25) {
        var Movie;
        (function (Movie) {
            var MovieDialog = (function (_super) {
                __extends(MovieDialog, _super);
                function MovieDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.MovieForm(this.idPrefix);
                }
                MovieDialog.prototype.getFormKey = function () { return Movie.MovieForm.formKey; };
                MovieDialog.prototype.getIdProperty = function () { return Movie.MovieRow.idProperty; };
                MovieDialog.prototype.getLocalTextPrefix = function () { return Movie.MovieRow.localTextPrefix; };
                MovieDialog.prototype.getNameProperty = function () { return Movie.MovieRow.nameProperty; };
                MovieDialog.prototype.getService = function () { return Movie.MovieService.baseUrl; };
                MovieDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], MovieDialog);
                return MovieDialog;
            }(Serenity.EntityDialog));
            Movie.MovieDialog = MovieDialog;
        })(Movie = Movie_25.Movie || (Movie_25.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_26) {
        var Movie;
        (function (Movie) {
            var MovieEditor = (function (_super) {
                __extends(MovieEditor, _super);
                function MovieEditor(container) {
                    _super.call(this, container);
                }
                MovieEditor.prototype.getColumnsKey = function () { return 'Movie.Movie'; };
                MovieEditor.prototype.getDialogType = function () { return Movie.MovieEditorDialog; };
                MovieEditor.prototype.getLocalTextPrefix = function () { return Movie.MovieRow.localTextPrefix; };
                MovieEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], MovieEditor);
                return MovieEditor;
            }(Movie_26.Common.GridEditorBase));
            Movie.MovieEditor = MovieEditor;
        })(Movie = Movie_26.Movie || (Movie_26.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_27) {
        var Movie;
        (function (Movie) {
            var MovieEditorDialog = (function (_super) {
                __extends(MovieEditorDialog, _super);
                function MovieEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.MovieForm(this.idPrefix);
                }
                MovieEditorDialog.prototype.getFormKey = function () { return Movie.MovieForm.formKey; };
                MovieEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.MovieRow.localTextPrefix; };
                MovieEditorDialog.prototype.getNameProperty = function () { return Movie.MovieRow.nameProperty; };
                MovieEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], MovieEditorDialog);
                return MovieEditorDialog;
            }(Movie_27.Common.GridEditorDialog));
            Movie.MovieEditorDialog = MovieEditorDialog;
        })(Movie = Movie_27.Movie || (Movie_27.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_28) {
        var Movie;
        (function (Movie) {
            var MovieGrid = (function (_super) {
                __extends(MovieGrid, _super);
                function MovieGrid(container) {
                    _super.call(this, container);
                }
                MovieGrid.prototype.getColumnsKey = function () { return 'Movie.Movie'; };
                MovieGrid.prototype.getDialogType = function () { return Movie.MovieDialog; };
                MovieGrid.prototype.getIdProperty = function () { return Movie.MovieRow.idProperty; };
                MovieGrid.prototype.getLocalTextPrefix = function () { return Movie.MovieRow.localTextPrefix; };
                MovieGrid.prototype.getService = function () { return Movie.MovieService.baseUrl; };
                MovieGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], MovieGrid);
                return MovieGrid;
            }(Serenity.EntityGrid));
            Movie.MovieGrid = MovieGrid;
        })(Movie = Movie_28.Movie || (Movie_28.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_29) {
        var Movie;
        (function (Movie) {
            var GenreDialog = (function (_super) {
                __extends(GenreDialog, _super);
                function GenreDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.GenreForm(this.idPrefix);
                }
                GenreDialog.prototype.getFormKey = function () { return Movie.GenreForm.formKey; };
                GenreDialog.prototype.getIdProperty = function () { return Movie.GenreRow.idProperty; };
                GenreDialog.prototype.getLocalTextPrefix = function () { return Movie.GenreRow.localTextPrefix; };
                GenreDialog.prototype.getNameProperty = function () { return Movie.GenreRow.nameProperty; };
                GenreDialog.prototype.getService = function () { return Movie.GenreService.baseUrl; };
                GenreDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], GenreDialog);
                return GenreDialog;
            }(Serenity.EntityDialog));
            Movie.GenreDialog = GenreDialog;
        })(Movie = Movie_29.Movie || (Movie_29.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_30) {
        var Movie;
        (function (Movie) {
            var GenreEditor = (function (_super) {
                __extends(GenreEditor, _super);
                function GenreEditor(container) {
                    _super.call(this, container);
                }
                GenreEditor.prototype.getColumnsKey = function () { return 'Movie.Genre'; };
                GenreEditor.prototype.getDialogType = function () { return Movie.GenreEditorDialog; };
                GenreEditor.prototype.getLocalTextPrefix = function () { return Movie.GenreRow.localTextPrefix; };
                GenreEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], GenreEditor);
                return GenreEditor;
            }(Movie_30.Common.GridEditorBase));
            Movie.GenreEditor = GenreEditor;
        })(Movie = Movie_30.Movie || (Movie_30.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_31) {
        var Movie;
        (function (Movie) {
            var GenreEditorDialog = (function (_super) {
                __extends(GenreEditorDialog, _super);
                function GenreEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.GenreForm(this.idPrefix);
                }
                GenreEditorDialog.prototype.getFormKey = function () { return Movie.GenreForm.formKey; };
                GenreEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.GenreRow.localTextPrefix; };
                GenreEditorDialog.prototype.getNameProperty = function () { return Movie.GenreRow.nameProperty; };
                GenreEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], GenreEditorDialog);
                return GenreEditorDialog;
            }(Movie_31.Common.GridEditorDialog));
            Movie.GenreEditorDialog = GenreEditorDialog;
        })(Movie = Movie_31.Movie || (Movie_31.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_32) {
        var Movie;
        (function (Movie) {
            var GenreGrid = (function (_super) {
                __extends(GenreGrid, _super);
                function GenreGrid(container) {
                    _super.call(this, container);
                }
                GenreGrid.prototype.getColumnsKey = function () { return 'Movie.Genre'; };
                GenreGrid.prototype.getDialogType = function () { return Movie.GenreDialog; };
                GenreGrid.prototype.getIdProperty = function () { return Movie.GenreRow.idProperty; };
                GenreGrid.prototype.getLocalTextPrefix = function () { return Movie.GenreRow.localTextPrefix; };
                GenreGrid.prototype.getService = function () { return Movie.GenreService.baseUrl; };
                GenreGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], GenreGrid);
                return GenreGrid;
            }(Serenity.EntityGrid));
            Movie.GenreGrid = GenreGrid;
        })(Movie = Movie_32.Movie || (Movie_32.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_33) {
        var Movie;
        (function (Movie) {
            var CountryDialog = (function (_super) {
                __extends(CountryDialog, _super);
                function CountryDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.CountryForm(this.idPrefix);
                }
                CountryDialog.prototype.getFormKey = function () { return Movie.CountryForm.formKey; };
                CountryDialog.prototype.getIdProperty = function () { return Movie.CountryRow.idProperty; };
                CountryDialog.prototype.getLocalTextPrefix = function () { return Movie.CountryRow.localTextPrefix; };
                CountryDialog.prototype.getNameProperty = function () { return Movie.CountryRow.nameProperty; };
                CountryDialog.prototype.getService = function () { return Movie.CountryService.baseUrl; };
                CountryDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], CountryDialog);
                return CountryDialog;
            }(Serenity.EntityDialog));
            Movie.CountryDialog = CountryDialog;
        })(Movie = Movie_33.Movie || (Movie_33.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_34) {
        var Movie;
        (function (Movie) {
            var CountryEditor = (function (_super) {
                __extends(CountryEditor, _super);
                function CountryEditor(container) {
                    _super.call(this, container);
                }
                CountryEditor.prototype.getColumnsKey = function () { return 'Movie.Country'; };
                CountryEditor.prototype.getDialogType = function () { return Movie.CountryEditorDialog; };
                CountryEditor.prototype.getLocalTextPrefix = function () { return Movie.CountryRow.localTextPrefix; };
                CountryEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], CountryEditor);
                return CountryEditor;
            }(Movie_34.Common.GridEditorBase));
            Movie.CountryEditor = CountryEditor;
        })(Movie = Movie_34.Movie || (Movie_34.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_35) {
        var Movie;
        (function (Movie) {
            var CountryEditorDialog = (function (_super) {
                __extends(CountryEditorDialog, _super);
                function CountryEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.CountryForm(this.idPrefix);
                }
                CountryEditorDialog.prototype.getFormKey = function () { return Movie.CountryForm.formKey; };
                CountryEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.CountryRow.localTextPrefix; };
                CountryEditorDialog.prototype.getNameProperty = function () { return Movie.CountryRow.nameProperty; };
                CountryEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], CountryEditorDialog);
                return CountryEditorDialog;
            }(Movie_35.Common.GridEditorDialog));
            Movie.CountryEditorDialog = CountryEditorDialog;
        })(Movie = Movie_35.Movie || (Movie_35.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_36) {
        var Movie;
        (function (Movie) {
            var CountryGrid = (function (_super) {
                __extends(CountryGrid, _super);
                function CountryGrid(container) {
                    _super.call(this, container);
                }
                CountryGrid.prototype.getColumnsKey = function () { return 'Movie.Country'; };
                CountryGrid.prototype.getDialogType = function () { return Movie.CountryDialog; };
                CountryGrid.prototype.getIdProperty = function () { return Movie.CountryRow.idProperty; };
                CountryGrid.prototype.getLocalTextPrefix = function () { return Movie.CountryRow.localTextPrefix; };
                CountryGrid.prototype.getService = function () { return Movie.CountryService.baseUrl; };
                CountryGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], CountryGrid);
                return CountryGrid;
            }(Serenity.EntityGrid));
            Movie.CountryGrid = CountryGrid;
        })(Movie = Movie_36.Movie || (Movie_36.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_37) {
        var Movie;
        (function (Movie) {
            var CastDialog = (function (_super) {
                __extends(CastDialog, _super);
                function CastDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.CastForm(this.idPrefix);
                }
                CastDialog.prototype.getFormKey = function () { return Movie.CastForm.formKey; };
                CastDialog.prototype.getIdProperty = function () { return Movie.CastRow.idProperty; };
                CastDialog.prototype.getLocalTextPrefix = function () { return Movie.CastRow.localTextPrefix; };
                CastDialog.prototype.getNameProperty = function () { return Movie.CastRow.nameProperty; };
                CastDialog.prototype.getService = function () { return Movie.CastService.baseUrl; };
                CastDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], CastDialog);
                return CastDialog;
            }(Serenity.EntityDialog));
            Movie.CastDialog = CastDialog;
        })(Movie = Movie_37.Movie || (Movie_37.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_38) {
        var Movie;
        (function (Movie) {
            var CastEditor = (function (_super) {
                __extends(CastEditor, _super);
                function CastEditor(container) {
                    _super.call(this, container);
                }
                CastEditor.prototype.getColumnsKey = function () { return 'Movie.Cast'; };
                CastEditor.prototype.getDialogType = function () { return Movie.CastEditorDialog; };
                CastEditor.prototype.getLocalTextPrefix = function () { return Movie.CastRow.localTextPrefix; };
                CastEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], CastEditor);
                return CastEditor;
            }(Movie_38.Common.GridEditorBase));
            Movie.CastEditor = CastEditor;
        })(Movie = Movie_38.Movie || (Movie_38.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_39) {
        var Movie;
        (function (Movie) {
            var CastEditorDialog = (function (_super) {
                __extends(CastEditorDialog, _super);
                function CastEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Movie.CastForm(this.idPrefix);
                }
                CastEditorDialog.prototype.getFormKey = function () { return Movie.CastForm.formKey; };
                CastEditorDialog.prototype.getLocalTextPrefix = function () { return Movie.CastRow.localTextPrefix; };
                CastEditorDialog.prototype.getNameProperty = function () { return Movie.CastRow.nameProperty; };
                CastEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], CastEditorDialog);
                return CastEditorDialog;
            }(Movie_39.Common.GridEditorDialog));
            Movie.CastEditorDialog = CastEditorDialog;
        })(Movie = Movie_39.Movie || (Movie_39.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_40) {
        var Movie;
        (function (Movie) {
            var CastGrid = (function (_super) {
                __extends(CastGrid, _super);
                function CastGrid(container) {
                    _super.call(this, container);
                }
                CastGrid.prototype.getColumnsKey = function () { return 'Movie.Cast'; };
                CastGrid.prototype.getDialogType = function () { return Movie.CastDialog; };
                CastGrid.prototype.getIdProperty = function () { return Movie.CastRow.idProperty; };
                CastGrid.prototype.getLocalTextPrefix = function () { return Movie.CastRow.localTextPrefix; };
                CastGrid.prototype.getService = function () { return Movie.CastService.baseUrl; };
                CastGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], CastGrid);
                return CastGrid;
            }(Serenity.EntityGrid));
            Movie.CastGrid = CastGrid;
        })(Movie = Movie_40.Movie || (Movie_40.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var LoginPanel = (function (_super) {
                __extends(LoginPanel, _super);
                function LoginPanel(container) {
                    var _this = this;
                    _super.call(this, container);
                    $(function () {
                        $('body').vegas({
                            delay: 10000,
                            cover: true,
                            overlay: Q.resolveUrl("~/scripts/vegas/overlays/01.png"),
                            slides: [
                                { src: Q.resolveUrl('~/content/site/slides/slide1.jpg'), transition: 'fade' },
                                { src: Q.resolveUrl('~/content/site/slides/slide2.jpg'), transition: 'fade' },
                                { src: Q.resolveUrl('~/content/site/slides/slide3.jpg'), transition: 'zoomOut' },
                                { src: Q.resolveUrl('~/content/site/slides/slide4.jpg'), transition: 'blur' },
                                { src: Q.resolveUrl('~/content/site/slides/slide5.jpg'), transition: 'swirlLeft' }
                            ]
                        });
                    });
                    this.form = new Membership.LoginForm(this.idPrefix);
                    this.byId('LoginButton').click(function (e) {
                        e.preventDefault();
                        if (!_this.validateForm()) {
                            return;
                        }
                        var request = _this.getSaveEntity();
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Account/Login'),
                            request: request,
                            onSuccess: function (response) {
                                var q = Q.parseQueryString();
                                var returnUrl = q['returnUrl'] || q['ReturnUrl'];
                                if (returnUrl) {
                                    window.location.href = returnUrl;
                                }
                                else {
                                    window.location.href = Q.resolveUrl('~/');
                                }
                            }
                        });
                    });
                }
                LoginPanel.prototype.getFormKey = function () { return Membership.LoginForm.formKey; };
                LoginPanel = __decorate([
                    Serenity.Decorators.registerClass()
                ], LoginPanel);
                return LoginPanel;
            }(Serenity.PropertyPanel));
            Membership.LoginPanel = LoginPanel;
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var SignUpPanel = (function (_super) {
                __extends(SignUpPanel, _super);
                function SignUpPanel(container) {
                    var _this = this;
                    _super.call(this, container);
                    this.form = new Membership.SignUpForm(this.idPrefix);
                    this.form.ConfirmEmail.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.ConfirmEmail.value !== _this.form.Email.value) {
                            return Q.text('Validation.EmailConfirm');
                        }
                    });
                    this.form.ConfirmPassword.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.ConfirmPassword.value !== _this.form.Password.value) {
                            return Q.text('Validation.PasswordConfirm');
                        }
                    });
                    this.byId('SubmitButton').click(function (e) {
                        e.preventDefault();
                        if (!_this.validateForm()) {
                            return;
                        }
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Account/SignUp'),
                            request: {
                                DisplayName: _this.form.DisplayName.value,
                                Email: _this.form.Email.value,
                                Password: _this.form.Password.value
                            },
                            onSuccess: function (response) {
                                Q.information(Q.text('Forms.Membership.SignUp.Success'), function () {
                                    window.location.href = Q.resolveUrl('~/');
                                });
                            }
                        });
                    });
                }
                SignUpPanel.prototype.getFormKey = function () { return Membership.SignUpForm.formKey; };
                SignUpPanel = __decorate([
                    Serenity.Decorators.registerClass()
                ], SignUpPanel);
                return SignUpPanel;
            }(Serenity.PropertyPanel));
            Membership.SignUpPanel = SignUpPanel;
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ResetPasswordPanel = (function (_super) {
                __extends(ResetPasswordPanel, _super);
                function ResetPasswordPanel(container) {
                    var _this = this;
                    _super.call(this, container);
                    this.form = new Membership.ResetPasswordForm(this.idPrefix);
                    this.form.NewPassword.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.ConfirmPassword.value.length < 7) {
                            return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                        }
                    });
                    this.form.ConfirmPassword.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                            return Q.text('Validation.PasswordConfirm');
                        }
                    });
                    this.byId('SubmitButton').click(function (e) {
                        e.preventDefault();
                        if (!_this.validateForm()) {
                            return;
                        }
                        var request = _this.getSaveEntity();
                        request.Token = _this.byId('Token').val();
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Account/ResetPassword'),
                            request: request,
                            onSuccess: function (response) {
                                Q.information(Q.text('Forms.Membership.ResetPassword.Success'), function () {
                                    window.location.href = Q.resolveUrl('~/Account/Login');
                                });
                            }
                        });
                    });
                }
                ResetPasswordPanel.prototype.getFormKey = function () { return Membership.ResetPasswordForm.formKey; };
                ResetPasswordPanel = __decorate([
                    Serenity.Decorators.registerClass()
                ], ResetPasswordPanel);
                return ResetPasswordPanel;
            }(Serenity.PropertyPanel));
            Membership.ResetPasswordPanel = ResetPasswordPanel;
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ForgotPasswordPanel = (function (_super) {
                __extends(ForgotPasswordPanel, _super);
                function ForgotPasswordPanel(container) {
                    var _this = this;
                    _super.call(this, container);
                    this.form = new Membership.ForgotPasswordForm(this.idPrefix);
                    this.byId('SubmitButton').click(function (e) {
                        e.preventDefault();
                        if (!_this.validateForm()) {
                            return;
                        }
                        var request = _this.getSaveEntity();
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Account/ForgotPassword'),
                            request: request,
                            onSuccess: function (response) {
                                Q.information(Q.text('Forms.Membership.ForgotPassword.Success'), function () {
                                    window.location.href = Q.resolveUrl('~/');
                                });
                            }
                        });
                    });
                }
                ForgotPasswordPanel.prototype.getFormKey = function () { return Membership.ForgotPasswordForm.formKey; };
                ForgotPasswordPanel = __decorate([
                    Serenity.Decorators.registerClass()
                ], ForgotPasswordPanel);
                return ForgotPasswordPanel;
            }(Serenity.PropertyPanel));
            Membership.ForgotPasswordPanel = ForgotPasswordPanel;
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ChangePasswordPanel = (function (_super) {
                __extends(ChangePasswordPanel, _super);
                function ChangePasswordPanel(container) {
                    var _this = this;
                    _super.call(this, container);
                    this.form = new Membership.ChangePasswordForm(this.idPrefix);
                    this.form.NewPassword.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.w('ConfirmPassword', Serenity.PasswordEditor).value.length < 7) {
                            return Q.format(Q.text('Validation.MinRequiredPasswordLength'), 7);
                        }
                    });
                    this.form.ConfirmPassword.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.ConfirmPassword.value !== _this.form.NewPassword.value) {
                            return Q.text('Validation.PasswordConfirm');
                        }
                    });
                    this.byId('SubmitButton').click(function (e) {
                        e.preventDefault();
                        if (!_this.validateForm()) {
                            return;
                        }
                        var request = _this.getSaveEntity();
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Account/ChangePassword'),
                            request: request,
                            onSuccess: function (response) {
                                Q.information(Q.text('Forms.Membership.ChangePassword.Success'), function () {
                                    window.location.href = Q.resolveUrl('~/');
                                });
                            }
                        });
                    });
                }
                ChangePasswordPanel.prototype.getFormKey = function () { return Membership.ChangePasswordForm.formKey; };
                ChangePasswordPanel = __decorate([
                    Serenity.Decorators.registerClass()
                ], ChangePasswordPanel);
                return ChangePasswordPanel;
            }(Serenity.PropertyPanel));
            Membership.ChangePasswordPanel = ChangePasswordPanel;
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsDialog = (function (_super) {
                __extends(SettingsDialog, _super);
                function SettingsDialog() {
                    _super.apply(this, arguments);
                    this.form = new Configuration.SettingsForm(this.idPrefix);
                }
                SettingsDialog.prototype.getFormKey = function () { return Configuration.SettingsForm.formKey; };
                SettingsDialog.prototype.getIdProperty = function () { return Configuration.SettingsRow.idProperty; };
                SettingsDialog.prototype.getLocalTextPrefix = function () { return Configuration.SettingsRow.localTextPrefix; };
                SettingsDialog.prototype.getNameProperty = function () { return Configuration.SettingsRow.nameProperty; };
                SettingsDialog.prototype.getService = function () { return Configuration.SettingsService.baseUrl; };
                SettingsDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], SettingsDialog);
                return SettingsDialog;
            }(Serenity.EntityDialog));
            Configuration.SettingsDialog = SettingsDialog;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsEditor = (function (_super) {
                __extends(SettingsEditor, _super);
                function SettingsEditor(container) {
                    _super.call(this, container);
                }
                SettingsEditor.prototype.getColumnsKey = function () { return 'Configuration.Settings'; };
                SettingsEditor.prototype.getDialogType = function () { return Configuration.SettingsEditorDialog; };
                SettingsEditor.prototype.getLocalTextPrefix = function () { return Configuration.SettingsRow.localTextPrefix; };
                SettingsEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], SettingsEditor);
                return SettingsEditor;
            }(Movie.Common.GridEditorBase));
            Configuration.SettingsEditor = SettingsEditor;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsEditorDialog = (function (_super) {
                __extends(SettingsEditorDialog, _super);
                function SettingsEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Configuration.SettingsForm(this.idPrefix);
                }
                SettingsEditorDialog.prototype.getFormKey = function () { return Configuration.SettingsForm.formKey; };
                SettingsEditorDialog.prototype.getLocalTextPrefix = function () { return Configuration.SettingsRow.localTextPrefix; };
                SettingsEditorDialog.prototype.getNameProperty = function () { return Configuration.SettingsRow.nameProperty; };
                SettingsEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], SettingsEditorDialog);
                return SettingsEditorDialog;
            }(Movie.Common.GridEditorDialog));
            Configuration.SettingsEditorDialog = SettingsEditorDialog;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsGrid = (function (_super) {
                __extends(SettingsGrid, _super);
                function SettingsGrid(container) {
                    _super.call(this, container);
                }
                SettingsGrid.prototype.getColumnsKey = function () { return 'Configuration.Settings'; };
                SettingsGrid.prototype.getDialogType = function () { return Configuration.SettingsDialog; };
                SettingsGrid.prototype.getIdProperty = function () { return Configuration.SettingsRow.idProperty; };
                SettingsGrid.prototype.getLocalTextPrefix = function () { return Configuration.SettingsRow.localTextPrefix; };
                SettingsGrid.prototype.getService = function () { return Configuration.SettingsService.baseUrl; };
                SettingsGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], SettingsGrid);
                return SettingsGrid;
            }(Serenity.EntityGrid));
            Configuration.SettingsGrid = SettingsGrid;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundDialog = (function (_super) {
                __extends(BackgroundDialog, _super);
                function BackgroundDialog() {
                    _super.apply(this, arguments);
                    this.form = new Configuration.BackgroundForm(this.idPrefix);
                }
                BackgroundDialog.prototype.getFormKey = function () { return Configuration.BackgroundForm.formKey; };
                BackgroundDialog.prototype.getIdProperty = function () { return Configuration.BackgroundRow.idProperty; };
                BackgroundDialog.prototype.getLocalTextPrefix = function () { return Configuration.BackgroundRow.localTextPrefix; };
                BackgroundDialog.prototype.getNameProperty = function () { return Configuration.BackgroundRow.nameProperty; };
                BackgroundDialog.prototype.getService = function () { return Configuration.BackgroundService.baseUrl; };
                BackgroundDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], BackgroundDialog);
                return BackgroundDialog;
            }(Serenity.EntityDialog));
            Configuration.BackgroundDialog = BackgroundDialog;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundEditor = (function (_super) {
                __extends(BackgroundEditor, _super);
                function BackgroundEditor(container) {
                    _super.call(this, container);
                }
                BackgroundEditor.prototype.getColumnsKey = function () { return 'Configuration.Background'; };
                BackgroundEditor.prototype.getDialogType = function () { return Configuration.BackgroundEditorDialog; };
                BackgroundEditor.prototype.getLocalTextPrefix = function () { return Configuration.BackgroundRow.localTextPrefix; };
                BackgroundEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], BackgroundEditor);
                return BackgroundEditor;
            }(Movie.Common.GridEditorBase));
            Configuration.BackgroundEditor = BackgroundEditor;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundEditorDialog = (function (_super) {
                __extends(BackgroundEditorDialog, _super);
                function BackgroundEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Configuration.BackgroundForm(this.idPrefix);
                }
                BackgroundEditorDialog.prototype.getFormKey = function () { return Configuration.BackgroundForm.formKey; };
                BackgroundEditorDialog.prototype.getLocalTextPrefix = function () { return Configuration.BackgroundRow.localTextPrefix; };
                BackgroundEditorDialog.prototype.getNameProperty = function () { return Configuration.BackgroundRow.nameProperty; };
                BackgroundEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], BackgroundEditorDialog);
                return BackgroundEditorDialog;
            }(Movie.Common.GridEditorDialog));
            Configuration.BackgroundEditorDialog = BackgroundEditorDialog;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundGrid = (function (_super) {
                __extends(BackgroundGrid, _super);
                function BackgroundGrid(container) {
                    _super.call(this, container);
                }
                BackgroundGrid.prototype.getColumnsKey = function () { return 'Configuration.Background'; };
                BackgroundGrid.prototype.getDialogType = function () { return Configuration.BackgroundDialog; };
                BackgroundGrid.prototype.getIdProperty = function () { return Configuration.BackgroundRow.idProperty; };
                BackgroundGrid.prototype.getLocalTextPrefix = function () { return Configuration.BackgroundRow.localTextPrefix; };
                BackgroundGrid.prototype.getService = function () { return Configuration.BackgroundService.baseUrl; };
                BackgroundGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], BackgroundGrid);
                return BackgroundGrid;
            }(Serenity.EntityGrid));
            Configuration.BackgroundGrid = BackgroundGrid;
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var ScriptInitialization;
        (function (ScriptInitialization) {
            Q.Config.responsiveDialogs = true;
            Q.Config.rootNamespaces.push('Cinema.Movie');
        })(ScriptInitialization = Movie.ScriptInitialization || (Movie.ScriptInitialization = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var UserPreferenceStorage = (function () {
                function UserPreferenceStorage() {
                }
                UserPreferenceStorage.prototype.getItem = function (key) {
                    var value;
                    Common.UserPreferenceService.Retrieve({
                        PreferenceType: "UserPreferenceStorage",
                        Name: key
                    }, function (response) { return value = response.Value; }, {
                        async: false
                    });
                    return value;
                };
                UserPreferenceStorage.prototype.setItem = function (key, data) {
                    Common.UserPreferenceService.Update({
                        PreferenceType: "UserPreferenceStorage",
                        Name: key,
                        Value: data
                    });
                };
                return UserPreferenceStorage;
            }());
            Common.UserPreferenceStorage = UserPreferenceStorage;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var PdfExportHelper;
            (function (PdfExportHelper) {
                function toAutoTableColumns(srcColumns, columnStyles, columnTitles) {
                    return srcColumns.map(function (src) {
                        var col = {
                            dataKey: src.id || src.field,
                            title: src.name || ''
                        };
                        if (columnTitles && columnTitles[col.dataKey] != null)
                            col.title = columnTitles[col.dataKey];
                        var style = {};
                        if ((src.cssClass || '').indexOf("align-right") >= 0)
                            style.halign = 'right';
                        else if ((src.cssClass || '').indexOf("align-center") >= 0)
                            style.halign = 'center';
                        columnStyles[col.dataKey] = style;
                        return col;
                    });
                }
                function toAutoTableData(entities, keys, srcColumns) {
                    var el = document.createElement('span');
                    var row = 0;
                    return entities.map(function (item) {
                        var dst = {};
                        for (var cell = 0; cell < srcColumns.length; cell++) {
                            var src = srcColumns[cell];
                            var fld = src.field || '';
                            var key = keys[cell];
                            var txt = void 0;
                            var html = void 0;
                            if (src.formatter) {
                                html = src.formatter(row, cell, item[fld], src, item);
                            }
                            else if (src.format) {
                                html = src.format({ row: row, cell: cell, item: item, value: item[fld] });
                            }
                            else {
                                dst[key] = item[fld];
                                continue;
                            }
                            if (!html || (html.indexOf('<') < 0 && html.indexOf('&') < 0))
                                dst[key] = html;
                            else {
                                el.innerHTML = html;
                                if (el.children.length == 1 &&
                                    $(el.children[0]).is(":input")) {
                                    dst[key] = $(el.children[0]).val();
                                }
                                else if (el.children.length == 1 &&
                                    $(el.children).is('.check-box')) {
                                    dst[key] = $(el.children).hasClass("checked") ? "X" : "";
                                }
                                else
                                    dst[key] = el.textContent || '';
                            }
                        }
                        row++;
                        return dst;
                    });
                }
                function exportToPdf(options) {
                    var g = options.grid;
                    if (!options.onViewSubmit())
                        return;
                    includeAutoTable();
                    var request = Q.deepClone(g.view.params);
                    request.Take = 0;
                    request.Skip = 0;
                    var sortBy = g.view.sortBy;
                    if (sortBy != null)
                        request.Sort = sortBy;
                    var gridColumns = g.slickGrid.getColumns();
                    gridColumns = gridColumns.filter(function (x) { return x.id !== "__select__"; });
                    request.IncludeColumns = [];
                    for (var _i = 0, gridColumns_1 = gridColumns; _i < gridColumns_1.length; _i++) {
                        var column = gridColumns_1[_i];
                        request.IncludeColumns.push(column.id || column.field);
                    }
                    Q.serviceCall({
                        url: g.view.url,
                        request: request,
                        onSuccess: function (response) {
                            var doc;
                            var srcColumns = gridColumns;
                            var columnStyles = {};
                            var columns = toAutoTableColumns(srcColumns, columnStyles, options.columnTitles);
                            var keys = columns.map(function (x) { return x.dataKey; });
                            var entities = response.Entities || [];
                            var data = toAutoTableData(entities, keys, srcColumns);
                            doc.setFontSize(options.titleFontSize || 10);
                            doc.setFontStyle('bold');
                            var reportTitle = options.reportTitle || g.getTitle() || "Report";
                            doc.autoTableText(reportTitle, doc.internal.pageSize.width / 2, options.titleTop || 25, { halign: 'center' });
                            var totalPagesExp = "{{T}}";
                            var pageNumbers = options.pageNumbers == null || options.pageNumbers;
                            var autoOptions = $.extend({
                                margin: { top: 25, left: 25, right: 25, bottom: pageNumbers ? 25 : 30 },
                                startY: 60,
                                styles: {
                                    fontSize: 8,
                                    overflow: 'linebreak',
                                    cellPadding: 2,
                                    valign: 'middle'
                                },
                                columnStyles: columnStyles
                            }, options.tableOptions);
                            if (pageNumbers) {
                                var footer = function (data) {
                                    var str = data.pageCount;
                                    // Total page number plugin only available in jspdf v1.0+
                                    if (typeof doc.putTotalPages === 'function') {
                                        str = str + " / " + totalPagesExp;
                                    }
                                    doc.autoTableText(str, doc.internal.pageSize.width / 2, doc.internal.pageSize.height - autoOptions.margin.bottom, {
                                        halign: 'center'
                                    });
                                };
                                autoOptions.afterPageContent = footer;
                            }
                            doc.autoTable(columns, data, autoOptions);
                            if (typeof doc.putTotalPages === 'function') {
                                doc.putTotalPages(totalPagesExp);
                            }
                            if (!options.output || options.output == "file") {
                                var fileName = options.reportTitle || "{0}_{1}.pdf";
                                fileName = Q.format(fileName, g.getTitle() || "report", Q.formatDate(new Date(), "yyyyMMdd_HHmm"));
                                doc.save(fileName);
                                return;
                            }
                            if (options.autoPrint)
                                doc.autoPrint();
                            var output = options.output;
                            if (output == 'newwindow' || '_blank')
                                output = 'dataurlnewwindow';
                            else if (output == 'window')
                                output = 'datauri';
                            doc.output(output);
                        }
                    });
                }
                PdfExportHelper.exportToPdf = exportToPdf;
                function createToolButton(options) {
                    return {
                        title: options.title || '',
                        hint: options.hint || 'PDF',
                        cssClass: 'export-pdf-button',
                        onClick: function () { return exportToPdf(options); },
                        separator: options.separator
                    };
                }
                PdfExportHelper.createToolButton = createToolButton;
                function includeJsPDF() {
                    //if (typeof jsPDF !== "undefined")
                    //    return;
                    var script = $("jsPDFScript");
                    if (script.length > 0)
                        return;
                    $("<script/>")
                        .attr("type", "text/javascript")
                        .attr("id", "jsPDFScript")
                        .attr("src", Q.resolveUrl("~/Scripts/jspdf.min.js"))
                        .appendTo(document.head);
                }
                function includeAutoTable() {
                    includeJsPDF();
                    //if (typeof jsPDF === "undefined" ||
                    //    typeof (jsPDF as any).API == "undefined" ||
                    //    typeof (jsPDF as any).API.autoTable !== "undefined")
                    //    return;
                    var script = $("jsPDFAutoTableScript");
                    if (script.length > 0)
                        return;
                    $("<script/>")
                        .attr("type", "text/javascript")
                        .attr("id", "jsPDFAutoTableScript")
                        .attr("src", Q.resolveUrl("~/Scripts/jspdf.plugin.autotable.min.js"))
                        .appendTo(document.head);
                }
            })(PdfExportHelper = Common.PdfExportHelper || (Common.PdfExportHelper = {}));
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var LanguageSelection = (function (_super) {
                __extends(LanguageSelection, _super);
                function LanguageSelection(select, currentLanguage) {
                    _super.call(this, select);
                    currentLanguage = Q.coalesce(currentLanguage, 'en');
                    this.change(function (e) {
                        $.cookie('LanguagePreference', select.val(), {
                            path: Q.Config.applicationPath,
                            expires: 365
                        });
                        window.location.reload(true);
                    });
                    Q.getLookupAsync('Administration.Language').then(function (x) {
                        if (!Q.any(x.items, function (z) { return z.LanguageId === currentLanguage; })) {
                            var idx = currentLanguage.lastIndexOf('-');
                            if (idx >= 0) {
                                currentLanguage = currentLanguage.substr(0, idx);
                                if (!Q.any(x.items, function (y) { return y.LanguageId === currentLanguage; })) {
                                    currentLanguage = 'en';
                                }
                            }
                            else {
                                currentLanguage = 'en';
                            }
                        }
                        for (var _i = 0, _a = x.items; _i < _a.length; _i++) {
                            var l = _a[_i];
                            Q.addOption(select, l.LanguageId, l.LanguageName);
                        }
                        select.val(currentLanguage);
                    });
                }
                return LanguageSelection;
            }(Serenity.Widget));
            Common.LanguageSelection = LanguageSelection;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var SidebarSearch = (function (_super) {
                __extends(SidebarSearch, _super);
                function SidebarSearch(input, menuUL) {
                    var _this = this;
                    _super.call(this, input);
                    new Serenity.QuickSearchInput(input, {
                        onSearch: function (field, text, success) {
                            _this.updateMatchFlags(text);
                            success(true);
                        }
                    });
                    this.menuUL = menuUL;
                }
                SidebarSearch.prototype.updateMatchFlags = function (text) {
                    var liList = this.menuUL.find('li').removeClass('non-match');
                    text = Q.trimToNull(text);
                    if (text == null) {
                        liList.show();
                        liList.removeClass('expanded');
                        return;
                    }
                    var parts = text.replace(',', ' ').split(' ').filter(function (x) { return !Q.isTrimmedEmpty(x); });
                    for (var i = 0; i < parts.length; i++) {
                        parts[i] = Q.trimToNull(Select2.util.stripDiacritics(parts[i]).toUpperCase());
                    }
                    var items = liList;
                    items.each(function (idx, e) {
                        var x = $(e);
                        var title = Select2.util.stripDiacritics(Q.coalesce(x.text(), '').toUpperCase());
                        for (var _i = 0, parts_1 = parts; _i < parts_1.length; _i++) {
                            var p = parts_1[_i];
                            if (p != null && !(title.indexOf(p) !== -1)) {
                                x.addClass('non-match');
                                break;
                            }
                        }
                    });
                    var matchingItems = items.not('.non-match');
                    var visibles = matchingItems.parents('li').add(matchingItems);
                    var nonVisibles = liList.not(visibles);
                    nonVisibles.hide().addClass('non-match');
                    visibles.show();
                    liList.addClass('expanded');
                };
                return SidebarSearch;
            }(Serenity.Widget));
            Common.SidebarSearch = SidebarSearch;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var ThemeSelection = (function (_super) {
                __extends(ThemeSelection, _super);
                function ThemeSelection(select) {
                    var _this = this;
                    _super.call(this, select);
                    this.change(function (e) {
                        $.cookie('ThemePreference', select.val(), {
                            path: Q.Config.applicationPath,
                            expires: 365
                        });
                        $('body').removeClass('skin-' + _this.getCurrentTheme());
                        $('body').addClass('skin-' + select.val());
                    });
                    Q.addOption(select, 'blue', Q.text('Site.Layout.ThemeBlue'));
                    Q.addOption(select, 'blue-light', Q.text('Site.Layout.ThemeBlueLight'));
                    Q.addOption(select, 'purple', Q.text('Site.Layout.ThemePurple'));
                    Q.addOption(select, 'purple-light', Q.text('Site.Layout.ThemePurpleLight'));
                    Q.addOption(select, 'red', Q.text('Site.Layout.ThemeRed'));
                    Q.addOption(select, 'red-light', Q.text('Site.Layout.ThemeRedLight'));
                    Q.addOption(select, 'green', Q.text('Site.Layout.ThemeGreen'));
                    Q.addOption(select, 'green-light', Q.text('Site.Layout.ThemeGreenLight'));
                    Q.addOption(select, 'yellow', Q.text('Site.Layout.ThemeYellow'));
                    Q.addOption(select, 'yellow-light', Q.text('Site.Layout.ThemeYellowLight'));
                    Q.addOption(select, 'black', Q.text('Site.Layout.ThemeBlack'));
                    Q.addOption(select, 'black-light', Q.text('Site.Layout.ThemeBlackLight'));
                    Q.addOption(select, 'modern', Q.text('Site.Layout.ThemeModern'));
                    Q.addOption(select, 'sunset', Q.text('Site.Layout.ThemeSunset'));
                    Q.addOption(select, 'tenderness', Q.text('Site.Layout.ThemeTenderness'));
                    Q.addOption(select, 'grapefruit', Q.text('Site.Layout.ThemeGrapefruit'));
                    Q.addOption(select, 'nature', Q.text('Site.Layout.ThemeNature'));
                    select.val(this.getCurrentTheme());
                }
                ThemeSelection.prototype.getCurrentTheme = function () {
                    var skinClass = Q.first(($('body').attr('class') || '').split(' '), function (x) { return Q.startsWith(x, 'skin-'); });
                    if (skinClass) {
                        return skinClass.substr(5);
                    }
                    return 'blue';
                };
                return ThemeSelection;
            }(Serenity.Widget));
            Common.ThemeSelection = ThemeSelection;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseForm = (function (_super) {
                __extends(DataBaseForm, _super);
                function DataBaseForm() {
                    _super.apply(this, arguments);
                }
                DataBaseForm.formKey = 'Administration.DataBase';
                return DataBaseForm;
            }(Serenity.PrefixedContext));
            Administration.DataBaseForm = DataBaseForm;
            [['Name', function () { return Serenity.StringEditor; }], ['ConnectionString', function () { return Serenity.StringEditor; }], ['ProviderName', function () { return Serenity.StringEditor; }], ['Active', function () { return Serenity.BooleanEditor; }], ['TagDataBaseMovie', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(DataBaseForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseRow;
            (function (DataBaseRow) {
                DataBaseRow.idProperty = 'DbId';
                DataBaseRow.nameProperty = 'Name';
                DataBaseRow.localTextPrefix = 'Administration.DataBase';
                var Fields;
                (function (Fields) {
                })(Fields = DataBaseRow.Fields || (DataBaseRow.Fields = {}));
                ['DbId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie'].forEach(function (x) { return Fields[x] = x; });
            })(DataBaseRow = Administration.DataBaseRow || (Administration.DataBaseRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseService;
            (function (DataBaseService) {
                DataBaseService.baseUrl = 'Administration/DataBase';
                var Methods;
                (function (Methods) {
                })(Methods = DataBaseService.Methods || (DataBaseService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    DataBaseService[x] = function (r, s, o) { return Q.serviceRequest(DataBaseService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = DataBaseService.baseUrl + '/' + x;
                });
            })(DataBaseService = Administration.DataBaseService || (Administration.DataBaseService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var LanguageForm = (function (_super) {
                __extends(LanguageForm, _super);
                function LanguageForm() {
                    _super.apply(this, arguments);
                }
                LanguageForm.formKey = 'Administration.Language';
                return LanguageForm;
            }(Serenity.PrefixedContext));
            Administration.LanguageForm = LanguageForm;
            [['LanguageId', function () { return Serenity.StringEditor; }], ['LanguageName', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(LanguageForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var LanguageRow;
            (function (LanguageRow) {
                LanguageRow.idProperty = 'Id';
                LanguageRow.nameProperty = 'LanguageName';
                LanguageRow.localTextPrefix = 'Administration.Language';
                LanguageRow.lookupKey = 'Administration.Language';
                function getLookup() {
                    return Q.getLookup('Administration.Language');
                }
                LanguageRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = LanguageRow.Fields || (LanguageRow.Fields = {}));
                ['Id', 'LanguageId', 'LanguageName'].forEach(function (x) { return Fields[x] = x; });
            })(LanguageRow = Administration.LanguageRow || (Administration.LanguageRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var LanguageService;
            (function (LanguageService) {
                LanguageService.baseUrl = 'Administration/Language';
                var Methods;
                (function (Methods) {
                })(Methods = LanguageService.Methods || (LanguageService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    LanguageService[x] = function (r, s, o) { return Q.serviceRequest(LanguageService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = LanguageService.baseUrl + '/' + x;
                });
            })(LanguageService = Administration.LanguageService || (Administration.LanguageService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleForm = (function (_super) {
                __extends(RoleForm, _super);
                function RoleForm() {
                    _super.apply(this, arguments);
                }
                RoleForm.formKey = 'Administration.Role';
                return RoleForm;
            }(Serenity.PrefixedContext));
            Administration.RoleForm = RoleForm;
            [['RoleName', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(RoleForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RolePermissionRow;
            (function (RolePermissionRow) {
                RolePermissionRow.idProperty = 'RolePermissionId';
                RolePermissionRow.nameProperty = 'PermissionKey';
                RolePermissionRow.localTextPrefix = 'Administration.RolePermission';
                var Fields;
                (function (Fields) {
                })(Fields = RolePermissionRow.Fields || (RolePermissionRow.Fields = {}));
                ['RolePermissionId', 'RoleId', 'PermissionKey', 'RoleRoleName'].forEach(function (x) { return Fields[x] = x; });
            })(RolePermissionRow = Administration.RolePermissionRow || (Administration.RolePermissionRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RolePermissionService;
            (function (RolePermissionService) {
                RolePermissionService.baseUrl = 'Administration/RolePermission';
                var Methods;
                (function (Methods) {
                })(Methods = RolePermissionService.Methods || (RolePermissionService.Methods = {}));
                ['Update', 'List'].forEach(function (x) {
                    RolePermissionService[x] = function (r, s, o) { return Q.serviceRequest(RolePermissionService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = RolePermissionService.baseUrl + '/' + x;
                });
            })(RolePermissionService = Administration.RolePermissionService || (Administration.RolePermissionService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleRow;
            (function (RoleRow) {
                RoleRow.idProperty = 'RoleId';
                RoleRow.nameProperty = 'RoleName';
                RoleRow.localTextPrefix = 'Administration.Role';
                RoleRow.lookupKey = 'Administration.Role';
                function getLookup() {
                    return Q.getLookup('Administration.Role');
                }
                RoleRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = RoleRow.Fields || (RoleRow.Fields = {}));
                ['RoleId', 'RoleName'].forEach(function (x) { return Fields[x] = x; });
            })(RoleRow = Administration.RoleRow || (Administration.RoleRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleService;
            (function (RoleService) {
                RoleService.baseUrl = 'Administration/Role';
                var Methods;
                (function (Methods) {
                })(Methods = RoleService.Methods || (RoleService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    RoleService[x] = function (r, s, o) { return Q.serviceRequest(RoleService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = RoleService.baseUrl + '/' + x;
                });
            })(RoleService = Administration.RoleService || (Administration.RoleService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var TranslationService;
            (function (TranslationService) {
                TranslationService.baseUrl = 'Administration/Translation';
                var Methods;
                (function (Methods) {
                })(Methods = TranslationService.Methods || (TranslationService.Methods = {}));
                ['List', 'Update'].forEach(function (x) {
                    TranslationService[x] = function (r, s, o) { return Q.serviceRequest(TranslationService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = TranslationService.baseUrl + '/' + x;
                });
            })(TranslationService = Administration.TranslationService || (Administration.TranslationService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserForm = (function (_super) {
                __extends(UserForm, _super);
                function UserForm() {
                    _super.apply(this, arguments);
                }
                UserForm.formKey = 'Administration.User';
                return UserForm;
            }(Serenity.PrefixedContext));
            Administration.UserForm = UserForm;
            [['Username', function () { return Serenity.StringEditor; }], ['DisplayName', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['UserImage', function () { return Serenity.ImageUploadEditor; }], ['Password', function () { return Serenity.PasswordEditor; }], ['PasswordConfirm', function () { return Serenity.PasswordEditor; }], ['Source', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(UserForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserPermissionRow;
            (function (UserPermissionRow) {
                UserPermissionRow.idProperty = 'UserPermissionId';
                UserPermissionRow.nameProperty = 'PermissionKey';
                UserPermissionRow.localTextPrefix = 'Administration.UserPermission';
                var Fields;
                (function (Fields) {
                })(Fields = UserPermissionRow.Fields || (UserPermissionRow.Fields = {}));
                ['UserPermissionId', 'UserId', 'PermissionKey', 'Granted', 'Username', 'User'].forEach(function (x) { return Fields[x] = x; });
            })(UserPermissionRow = Administration.UserPermissionRow || (Administration.UserPermissionRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserPermissionService;
            (function (UserPermissionService) {
                UserPermissionService.baseUrl = 'Administration/UserPermission';
                var Methods;
                (function (Methods) {
                })(Methods = UserPermissionService.Methods || (UserPermissionService.Methods = {}));
                ['Update', 'List', 'ListRolePermissions', 'ListPermissionKeys'].forEach(function (x) {
                    UserPermissionService[x] = function (r, s, o) { return Q.serviceRequest(UserPermissionService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = UserPermissionService.baseUrl + '/' + x;
                });
            })(UserPermissionService = Administration.UserPermissionService || (Administration.UserPermissionService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserRoleRow;
            (function (UserRoleRow) {
                UserRoleRow.idProperty = 'UserRoleId';
                UserRoleRow.localTextPrefix = 'Administration.UserRole';
                var Fields;
                (function (Fields) {
                })(Fields = UserRoleRow.Fields || (UserRoleRow.Fields = {}));
                ['UserRoleId', 'UserId', 'RoleId', 'Username', 'User'].forEach(function (x) { return Fields[x] = x; });
            })(UserRoleRow = Administration.UserRoleRow || (Administration.UserRoleRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserRoleService;
            (function (UserRoleService) {
                UserRoleService.baseUrl = 'Administration/UserRole';
                var Methods;
                (function (Methods) {
                })(Methods = UserRoleService.Methods || (UserRoleService.Methods = {}));
                ['Update', 'List'].forEach(function (x) {
                    UserRoleService[x] = function (r, s, o) { return Q.serviceRequest(UserRoleService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = UserRoleService.baseUrl + '/' + x;
                });
            })(UserRoleService = Administration.UserRoleService || (Administration.UserRoleService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserRow;
            (function (UserRow) {
                UserRow.idProperty = 'UserId';
                UserRow.isActiveProperty = 'IsActive';
                UserRow.nameProperty = 'Username';
                UserRow.localTextPrefix = 'Administration.User';
                var Fields;
                (function (Fields) {
                })(Fields = UserRow.Fields || (UserRow.Fields = {}));
                ['UserId', 'Username', 'Source', 'PasswordHash', 'PasswordSalt', 'DisplayName', 'Email', 'UserImage', 'LastDirectoryUpdate', 'IsActive', 'Password', 'PasswordConfirm', 'InsertUserId', 'InsertDate', 'UpdateUserId', 'UpdateDate'].forEach(function (x) { return Fields[x] = x; });
            })(UserRow = Administration.UserRow || (Administration.UserRow = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserService;
            (function (UserService) {
                UserService.baseUrl = 'Administration/User';
                var Methods;
                (function (Methods) {
                })(Methods = UserService.Methods || (UserService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Undelete', 'Retrieve', 'List'].forEach(function (x) {
                    UserService[x] = function (r, s, o) { return Q.serviceRequest(UserService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = UserService.baseUrl + '/' + x;
                });
            })(UserService = Administration.UserService || (Administration.UserService = {}));
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var UserPreferenceRow;
            (function (UserPreferenceRow) {
                UserPreferenceRow.idProperty = 'UserPreferenceId';
                UserPreferenceRow.nameProperty = 'Name';
                UserPreferenceRow.localTextPrefix = 'Common.UserPreference';
                var Fields;
                (function (Fields) {
                })(Fields = UserPreferenceRow.Fields || (UserPreferenceRow.Fields = {}));
                ['UserPreferenceId', 'UserId', 'PreferenceType', 'Name', 'Value'].forEach(function (x) { return Fields[x] = x; });
            })(UserPreferenceRow = Common.UserPreferenceRow || (Common.UserPreferenceRow = {}));
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var UserPreferenceService;
            (function (UserPreferenceService) {
                UserPreferenceService.baseUrl = 'Common/UserPreference';
                var Methods;
                (function (Methods) {
                })(Methods = UserPreferenceService.Methods || (UserPreferenceService.Methods = {}));
                ['Update', 'Retrieve'].forEach(function (x) {
                    UserPreferenceService[x] = function (r, s, o) { return Q.serviceRequest(UserPreferenceService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = UserPreferenceService.baseUrl + '/' + x;
                });
            })(UserPreferenceService = Common.UserPreferenceService || (Common.UserPreferenceService = {}));
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundForm = (function (_super) {
                __extends(BackgroundForm, _super);
                function BackgroundForm() {
                    _super.apply(this, arguments);
                }
                BackgroundForm.formKey = 'Configuration.Background';
                return BackgroundForm;
            }(Serenity.PrefixedContext));
            Configuration.BackgroundForm = BackgroundForm;
            [['Color', function () { return Serenity.StringEditor; }], ['Path', function () { return Serenity.StringEditor; }], ['Size', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(BackgroundForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundRow;
            (function (BackgroundRow) {
                BackgroundRow.idProperty = 'BackgroundId';
                BackgroundRow.nameProperty = 'Color';
                BackgroundRow.localTextPrefix = 'Configuration.Background';
                var Fields;
                (function (Fields) {
                })(Fields = BackgroundRow.Fields || (BackgroundRow.Fields = {}));
                ['BackgroundId', 'Color', 'Path', 'Size'].forEach(function (x) { return Fields[x] = x; });
            })(BackgroundRow = Configuration.BackgroundRow || (Configuration.BackgroundRow = {}));
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var BackgroundService;
            (function (BackgroundService) {
                BackgroundService.baseUrl = 'Configuration/Background';
                var Methods;
                (function (Methods) {
                })(Methods = BackgroundService.Methods || (BackgroundService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    BackgroundService[x] = function (r, s, o) { return Q.serviceRequest(BackgroundService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = BackgroundService.baseUrl + '/' + x;
                });
            })(BackgroundService = Configuration.BackgroundService || (Configuration.BackgroundService = {}));
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsForm = (function (_super) {
                __extends(SettingsForm, _super);
                function SettingsForm() {
                    _super.apply(this, arguments);
                }
                SettingsForm.formKey = 'Configuration.Settings';
                return SettingsForm;
            }(Serenity.PrefixedContext));
            Configuration.SettingsForm = SettingsForm;
            [['Setting', function () { return Serenity.StringEditor; }], ['Value', function () { return Serenity.StringEditor; }], ['Type', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(SettingsForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsRow;
            (function (SettingsRow) {
                SettingsRow.idProperty = 'SettingId';
                SettingsRow.nameProperty = 'Setting';
                SettingsRow.localTextPrefix = 'Configuration.Settings';
                var Fields;
                (function (Fields) {
                })(Fields = SettingsRow.Fields || (SettingsRow.Fields = {}));
                ['SettingId', 'Setting', 'Value', 'Type'].forEach(function (x) { return Fields[x] = x; });
            })(SettingsRow = Configuration.SettingsRow || (Configuration.SettingsRow = {}));
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Configuration;
        (function (Configuration) {
            var SettingsService;
            (function (SettingsService) {
                SettingsService.baseUrl = 'Configuration/Settings';
                var Methods;
                (function (Methods) {
                })(Methods = SettingsService.Methods || (SettingsService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    SettingsService[x] = function (r, s, o) { return Q.serviceRequest(SettingsService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = SettingsService.baseUrl + '/' + x;
                });
            })(SettingsService = Configuration.SettingsService || (Configuration.SettingsService = {}));
        })(Configuration = Movie.Configuration || (Movie.Configuration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var DataBase;
        (function (DataBase) {
            var DbForm = (function (_super) {
                __extends(DbForm, _super);
                function DbForm() {
                    _super.apply(this, arguments);
                }
                DbForm.formKey = 'DataBase.Db';
                return DbForm;
            }(Serenity.PrefixedContext));
            DataBase.DbForm = DbForm;
            [['DbId', function () { return Serenity.IntegerEditor; }], ['Name', function () { return Serenity.StringEditor; }], ['ConnectionString', function () { return Serenity.StringEditor; }], ['ProviderName', function () { return Serenity.StringEditor; }], ['Active', function () { return Serenity.BooleanEditor; }], ['TagDataBaseMovie', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(DbForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(DataBase = Movie.DataBase || (Movie.DataBase = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var DataBase;
        (function (DataBase) {
            var DbRow;
            (function (DbRow) {
                DbRow.idProperty = 'DbId';
                DbRow.nameProperty = 'Name';
                DbRow.localTextPrefix = 'DataBase.Db';
                var Fields;
                (function (Fields) {
                })(Fields = DbRow.Fields || (DbRow.Fields = {}));
                ['DbId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie'].forEach(function (x) { return Fields[x] = x; });
            })(DbRow = DataBase.DbRow || (DataBase.DbRow = {}));
        })(DataBase = Movie.DataBase || (Movie.DataBase = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var DataBase;
        (function (DataBase) {
            var DbService;
            (function (DbService) {
                DbService.baseUrl = 'DataBase/Db';
                var Methods;
                (function (Methods) {
                })(Methods = DbService.Methods || (DbService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    DbService[x] = function (r, s, o) { return Q.serviceRequest(DbService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = DbService.baseUrl + '/' + x;
                });
            })(DbService = DataBase.DbService || (DataBase.DbService = {}));
        })(DataBase = Movie.DataBase || (Movie.DataBase = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ChangePasswordForm = (function (_super) {
                __extends(ChangePasswordForm, _super);
                function ChangePasswordForm() {
                    _super.apply(this, arguments);
                }
                ChangePasswordForm.formKey = 'Membership.ChangePassword';
                return ChangePasswordForm;
            }(Serenity.PrefixedContext));
            Membership.ChangePasswordForm = ChangePasswordForm;
            [['OldPassword', function () { return Serenity.PasswordEditor; }], ['NewPassword', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(ChangePasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ForgotPasswordForm = (function (_super) {
                __extends(ForgotPasswordForm, _super);
                function ForgotPasswordForm() {
                    _super.apply(this, arguments);
                }
                ForgotPasswordForm.formKey = 'Membership.ForgotPassword';
                return ForgotPasswordForm;
            }(Serenity.PrefixedContext));
            Membership.ForgotPasswordForm = ForgotPasswordForm;
            [['Email', function () { return Serenity.EmailEditor; }]].forEach(function (x) { return Object.defineProperty(ForgotPasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var LoginForm = (function (_super) {
                __extends(LoginForm, _super);
                function LoginForm() {
                    _super.apply(this, arguments);
                }
                LoginForm.formKey = 'Membership.Login';
                return LoginForm;
            }(Serenity.PrefixedContext));
            Membership.LoginForm = LoginForm;
            [['Username', function () { return Serenity.StringEditor; }], ['Password', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(LoginForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var ResetPasswordForm = (function (_super) {
                __extends(ResetPasswordForm, _super);
                function ResetPasswordForm() {
                    _super.apply(this, arguments);
                }
                ResetPasswordForm.formKey = 'Membership.ResetPassword';
                return ResetPasswordForm;
            }(Serenity.PrefixedContext));
            Membership.ResetPasswordForm = ResetPasswordForm;
            [['NewPassword', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(ResetPasswordForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Membership;
        (function (Membership) {
            var SignUpForm = (function (_super) {
                __extends(SignUpForm, _super);
                function SignUpForm() {
                    _super.apply(this, arguments);
                }
                SignUpForm.formKey = 'Membership.SignUp';
                return SignUpForm;
            }(Serenity.PrefixedContext));
            Membership.SignUpForm = SignUpForm;
            [['DisplayName', function () { return Serenity.StringEditor; }], ['Email', function () { return Serenity.EmailEditor; }], ['ConfirmEmail', function () { return Serenity.EmailEditor; }], ['Password', function () { return Serenity.PasswordEditor; }], ['ConfirmPassword', function () { return Serenity.PasswordEditor; }]].forEach(function (x) { return Object.defineProperty(SignUpForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Membership = Movie.Membership || (Movie.Membership = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_41) {
        var Movie;
        (function (Movie) {
            var CastForm = (function (_super) {
                __extends(CastForm, _super);
                function CastForm() {
                    _super.apply(this, arguments);
                }
                CastForm.formKey = 'Movie.Cast';
                return CastForm;
            }(Serenity.PrefixedContext));
            Movie.CastForm = CastForm;
            [['Character', function () { return Serenity.StringEditor; }], ['MovieId', function () { return Serenity.LookupEditor; }], ['PersonId', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(CastForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_41.Movie || (Movie_41.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_42) {
        var Movie;
        (function (Movie) {
            var CastRow;
            (function (CastRow) {
                CastRow.idProperty = 'CastId';
                CastRow.nameProperty = 'Character';
                CastRow.localTextPrefix = 'Movie.Cast';
                CastRow.lookupKey = 'Movie.Cast';
                function getLookup() {
                    return Q.getLookup('Movie.Cast');
                }
                CastRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = CastRow.Fields || (CastRow.Fields = {}));
                ['CastId', 'Character', 'MovieId', 'PersonId', 'MovieTitleEn', 'MovieTitleOther', 'MovieYearStart', 'MovieYearEnd', 'MoviePathImage', 'PersonNameEn', 'PersonFullNameEn', 'PersonNameOther', 'PersonFullNameOther', 'PersonBirthDate', 'PersonDeathDate', 'PersonBirthPlace', 'PersonGender', 'PersonPathImage'].forEach(function (x) { return Fields[x] = x; });
            })(CastRow = Movie.CastRow || (Movie.CastRow = {}));
        })(Movie = Movie_42.Movie || (Movie_42.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_43) {
        var Movie;
        (function (Movie) {
            var CastService;
            (function (CastService) {
                CastService.baseUrl = 'Movie/Cast';
                var Methods;
                (function (Methods) {
                })(Methods = CastService.Methods || (CastService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    CastService[x] = function (r, s, o) { return Q.serviceRequest(CastService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = CastService.baseUrl + '/' + x;
                });
            })(CastService = Movie.CastService || (Movie.CastService = {}));
        })(Movie = Movie_43.Movie || (Movie_43.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_44) {
        var Movie;
        (function (Movie) {
            var CountryForm = (function (_super) {
                __extends(CountryForm, _super);
                function CountryForm() {
                    _super.apply(this, arguments);
                }
                CountryForm.formKey = 'Movie.Country';
                return CountryForm;
            }(Serenity.PrefixedContext));
            Movie.CountryForm = CountryForm;
            [['Name', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(CountryForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_44.Movie || (Movie_44.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_45) {
        var Movie;
        (function (Movie) {
            var CountryRow;
            (function (CountryRow) {
                CountryRow.idProperty = 'CountryId';
                CountryRow.nameProperty = 'Name';
                CountryRow.localTextPrefix = 'Movie.Country';
                CountryRow.lookupKey = 'Movie.Country';
                function getLookup() {
                    return Q.getLookup('Movie.Country');
                }
                CountryRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = CountryRow.Fields || (CountryRow.Fields = {}));
                ['CountryId', 'Name'].forEach(function (x) { return Fields[x] = x; });
            })(CountryRow = Movie.CountryRow || (Movie.CountryRow = {}));
        })(Movie = Movie_45.Movie || (Movie_45.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_46) {
        var Movie;
        (function (Movie) {
            var CountryService;
            (function (CountryService) {
                CountryService.baseUrl = 'Movie/Country';
                var Methods;
                (function (Methods) {
                })(Methods = CountryService.Methods || (CountryService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    CountryService[x] = function (r, s, o) { return Q.serviceRequest(CountryService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = CountryService.baseUrl + '/' + x;
                });
            })(CountryService = Movie.CountryService || (Movie.CountryService = {}));
        })(Movie = Movie_46.Movie || (Movie_46.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_47) {
        var Movie;
        (function (Movie) {
            (function (Gender) {
                Gender[Gender["Male"] = 0] = "Male";
                Gender[Gender["Female"] = 1] = "Female";
            })(Movie.Gender || (Movie.Gender = {}));
            var Gender = Movie.Gender;
            Serenity.Decorators.registerEnum(Gender, 'Movie.Person.Gender');
        })(Movie = Movie_47.Movie || (Movie_47.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_48) {
        var Movie;
        (function (Movie) {
            var GenreForm = (function (_super) {
                __extends(GenreForm, _super);
                function GenreForm() {
                    _super.apply(this, arguments);
                }
                GenreForm.formKey = 'Movie.Genre';
                return GenreForm;
            }(Serenity.PrefixedContext));
            Movie.GenreForm = GenreForm;
            [['Name', function () { return Serenity.StringEditor; }], ['Icon', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(GenreForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_48.Movie || (Movie_48.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_49) {
        var Movie;
        (function (Movie) {
            var GenreRow;
            (function (GenreRow) {
                GenreRow.idProperty = 'GenreId';
                GenreRow.nameProperty = 'Name';
                GenreRow.localTextPrefix = 'Movie.Genre';
                GenreRow.lookupKey = 'Movie.Genre';
                function getLookup() {
                    return Q.getLookup('Movie.Genre');
                }
                GenreRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = GenreRow.Fields || (GenreRow.Fields = {}));
                ['GenreId', 'Name', 'Icon', 'MovieList'].forEach(function (x) { return Fields[x] = x; });
            })(GenreRow = Movie.GenreRow || (Movie.GenreRow = {}));
        })(Movie = Movie_49.Movie || (Movie_49.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_50) {
        var Movie;
        (function (Movie) {
            var GenreService;
            (function (GenreService) {
                GenreService.baseUrl = 'Movie/Genre';
                var Methods;
                (function (Methods) {
                })(Methods = GenreService.Methods || (GenreService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    GenreService[x] = function (r, s, o) { return Q.serviceRequest(GenreService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = GenreService.baseUrl + '/' + x;
                });
            })(GenreService = Movie.GenreService || (Movie.GenreService = {}));
        })(Movie = Movie_50.Movie || (Movie_50.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_51) {
        var Movie;
        (function (Movie) {
            var MovieCastForm = (function (_super) {
                __extends(MovieCastForm, _super);
                function MovieCastForm() {
                    _super.apply(this, arguments);
                }
                MovieCastForm.formKey = 'Movie.MovieCast';
                return MovieCastForm;
            }(Serenity.PrefixedContext));
            Movie.MovieCastForm = MovieCastForm;
            [['Character', function () { return Serenity.StringEditor; }], ['MovieId', function () { return Serenity.IntegerEditor; }], ['PersonId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(MovieCastForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_51.Movie || (Movie_51.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_52) {
        var Movie;
        (function (Movie) {
            var MovieCastRow;
            (function (MovieCastRow) {
                MovieCastRow.idProperty = 'MovieCastId';
                MovieCastRow.nameProperty = 'Character';
                MovieCastRow.localTextPrefix = 'Movie.MovieCast';
                var Fields;
                (function (Fields) {
                })(Fields = MovieCastRow.Fields || (MovieCastRow.Fields = {}));
                ['MovieCastId', 'Character', 'MovieId', 'PersonId', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MoviePathMiniImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget', 'PersonFirstname', 'PersonLastname', 'PersonBirthDate', 'PersonBirthPlace', 'PersonGender', 'PersonHeight', 'PersonPathImage', 'PersonPathImageMini'].forEach(function (x) { return Fields[x] = x; });
            })(MovieCastRow = Movie.MovieCastRow || (Movie.MovieCastRow = {}));
        })(Movie = Movie_52.Movie || (Movie_52.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_53) {
        var Movie;
        (function (Movie) {
            var MovieCastService;
            (function (MovieCastService) {
                MovieCastService.baseUrl = 'Movie/MovieCast';
                var Methods;
                (function (Methods) {
                })(Methods = MovieCastService.Methods || (MovieCastService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    MovieCastService[x] = function (r, s, o) { return Q.serviceRequest(MovieCastService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = MovieCastService.baseUrl + '/' + x;
                });
            })(MovieCastService = Movie.MovieCastService || (Movie.MovieCastService = {}));
        })(Movie = Movie_53.Movie || (Movie_53.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_54) {
        var Movie;
        (function (Movie) {
            var MovieCountryRow;
            (function (MovieCountryRow) {
                MovieCountryRow.idProperty = 'MovieCountryId';
                MovieCountryRow.localTextPrefix = 'Movie.MovieCountry';
                MovieCountryRow.lookupKey = 'Movie.MovieCountry';
                function getLookup() {
                    return Q.getLookup('Movie.MovieCountry');
                }
                MovieCountryRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = MovieCountryRow.Fields || (MovieCountryRow.Fields = {}));
                ['MovieCountryId', 'MovieId', 'CountryId', 'CountryName'].forEach(function (x) { return Fields[x] = x; });
            })(MovieCountryRow = Movie.MovieCountryRow || (Movie.MovieCountryRow = {}));
        })(Movie = Movie_54.Movie || (Movie_54.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_55) {
        var Movie;
        (function (Movie) {
            var MovieForm = (function (_super) {
                __extends(MovieForm, _super);
                function MovieForm() {
                    _super.apply(this, arguments);
                }
                MovieForm.formKey = 'Movie.Movie';
                return MovieForm;
            }(Serenity.PrefixedContext));
            Movie.MovieForm = MovieForm;
            [['TitleOriginal', function () { return Serenity.StringEditor; }], ['TitleTranslation', function () { return Serenity.StringEditor; }], ['Url', function () { return Serenity.StringEditor; }], ['Description', function () { return Serenity.StringEditor; }], ['YearStart', function () { return Serenity.IntegerEditor; }], ['YearEnd', function () { return Serenity.IntegerEditor; }], ['ReleaseWorldDate', function () { return Serenity.DateEditor; }], ['ReleaseOtherDate', function () { return Serenity.DateEditor; }], ['ReleaseDvd', function () { return Serenity.DateEditor; }], ['Runtime', function () { return Serenity.IntegerEditor; }], ['CreateDateTime', function () { return Serenity.DateEditor; }], ['UpdateDateTime', function () { return Serenity.DateEditor; }], ['PublishDateTime', function () { return Serenity.DateEditor; }], ['Kind', function () { return Serenity.EnumEditor; }], ['Rating', function () { return Serenity.IntegerEditor; }], ['Mpaa', function () { return Serenity.StringEditor; }], ['PathImage', function () { return Serenity.StringEditor; }], ['Nice', function () { return Serenity.BooleanEditor; }], ['ContSeason', function () { return Serenity.IntegerEditor; }], ['LastEvent', function () { return Serenity.StringEditor; }], ['LastEventPublishDateTime', function () { return Serenity.DateEditor; }], ['Tagline', function () { return Serenity.StringEditor; }], ['Budget', function () { return Serenity.IntegerEditor; }], ['GenreList', function () { return Serenity.LookupEditor; }], ['TagList', function () { return Serenity.LookupEditor; }], ['CountryList', function () { return Serenity.LookupEditor; }]].forEach(function (x) { return Object.defineProperty(MovieForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_55.Movie || (Movie_55.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_56) {
        var Movie;
        (function (Movie) {
            var MovieGenresRow;
            (function (MovieGenresRow) {
                MovieGenresRow.idProperty = 'MovieGenreId';
                MovieGenresRow.localTextPrefix = 'Movie.MovieGenres';
                var Fields;
                (function (Fields) {
                })(Fields = MovieGenresRow.Fields || (MovieGenresRow.Fields = {}));
                ['MovieGenreId', 'MovieId', 'GenreId', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget', 'GenreName'].forEach(function (x) { return Fields[x] = x; });
            })(MovieGenresRow = Movie.MovieGenresRow || (Movie.MovieGenresRow = {}));
        })(Movie = Movie_56.Movie || (Movie_56.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_57) {
        var Movie;
        (function (Movie) {
            (function (MovieKind) {
                MovieKind[MovieKind["Film"] = 1] = "Film";
                MovieKind[MovieKind["TvSeries"] = 2] = "TvSeries";
                MovieKind[MovieKind["MiniSeries"] = 3] = "MiniSeries";
            })(Movie.MovieKind || (Movie.MovieKind = {}));
            var MovieKind = Movie.MovieKind;
            Serenity.Decorators.registerEnum(MovieKind, 'Movie.Movie.MovieKind');
        })(Movie = Movie_57.Movie || (Movie_57.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_58) {
        var Movie;
        (function (Movie) {
            var MovieRow;
            (function (MovieRow) {
                MovieRow.idProperty = 'MovieId';
                MovieRow.nameProperty = 'TitleOriginal';
                MovieRow.localTextPrefix = 'Movie.Movie';
                MovieRow.lookupKey = 'Movie.Movie';
                function getLookup() {
                    return Q.getLookup('Movie.Movie');
                }
                MovieRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = MovieRow.Fields || (MovieRow.Fields = {}));
                ['MovieId', 'TitleOriginal', 'TitleTranslation', 'Url', 'Description', 'YearStart', 'YearEnd', 'ReleaseWorldDate', 'ReleaseOtherDate', 'ReleaseDvd', 'Runtime', 'CreateDateTime', 'UpdateDateTime', 'PublishDateTime', 'Kind', 'Rating', 'Mpaa', 'PathImage', 'Nice', 'ContSeason', 'LastEvent', 'LastEventPublishDateTime', 'Tagline', 'Budget', 'GenreList', 'GenreListName', 'TagList', 'TagListName', 'CountryList', 'CountryListName'].forEach(function (x) { return Fields[x] = x; });
            })(MovieRow = Movie.MovieRow || (Movie.MovieRow = {}));
        })(Movie = Movie_58.Movie || (Movie_58.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_59) {
        var Movie;
        (function (Movie) {
            var MovieService;
            (function (MovieService) {
                MovieService.baseUrl = 'Movie/Movie';
                var Methods;
                (function (Methods) {
                })(Methods = MovieService.Methods || (MovieService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    MovieService[x] = function (r, s, o) { return Q.serviceRequest(MovieService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = MovieService.baseUrl + '/' + x;
                });
            })(MovieService = Movie.MovieService || (Movie.MovieService = {}));
        })(Movie = Movie_59.Movie || (Movie_59.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_60) {
        var Movie;
        (function (Movie) {
            var MovieTagRow;
            (function (MovieTagRow) {
                MovieTagRow.idProperty = 'MovieTagId';
                MovieTagRow.localTextPrefix = 'Movie.MovieTag';
                var Fields;
                (function (Fields) {
                })(Fields = MovieTagRow.Fields || (MovieTagRow.Fields = {}));
                ['MovieTagId', 'TagId', 'MovieId', 'TagName', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget'].forEach(function (x) { return Fields[x] = x; });
            })(MovieTagRow = Movie.MovieTagRow || (Movie.MovieTagRow = {}));
        })(Movie = Movie_60.Movie || (Movie_60.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_61) {
        var Movie;
        (function (Movie) {
            var PersonForm = (function (_super) {
                __extends(PersonForm, _super);
                function PersonForm() {
                    _super.apply(this, arguments);
                }
                PersonForm.formKey = 'Movie.Person';
                return PersonForm;
            }(Serenity.PrefixedContext));
            Movie.PersonForm = PersonForm;
            [['NameEn', function () { return Serenity.StringEditor; }], ['FullNameEn', function () { return Serenity.StringEditor; }], ['NameOther', function () { return Serenity.StringEditor; }], ['FullNameOther', function () { return Serenity.StringEditor; }], ['BirthDate', function () { return Serenity.DateEditor; }], ['DeathDate', function () { return Serenity.DateEditor; }], ['Gender', function () { return Serenity.EnumEditor; }], ['About', function () { return Serenity.StringEditor; }], ['PathImage', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(PersonForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_61.Movie || (Movie_61.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_62) {
        var Movie;
        (function (Movie) {
            var PersonRow;
            (function (PersonRow) {
                PersonRow.idProperty = 'PersonId';
                PersonRow.nameProperty = 'NameEn';
                PersonRow.localTextPrefix = 'Movie.Person';
                PersonRow.lookupKey = 'Movie.Person';
                function getLookup() {
                    return Q.getLookup('Movie.Person');
                }
                PersonRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = PersonRow.Fields || (PersonRow.Fields = {}));
                ['PersonId', 'NameEn', 'FullNameEn', 'NameOther', 'FullNameOther', 'BirthDate', 'DeathDate', 'Gender', 'About', 'PathImage'].forEach(function (x) { return Fields[x] = x; });
            })(PersonRow = Movie.PersonRow || (Movie.PersonRow = {}));
        })(Movie = Movie_62.Movie || (Movie_62.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_63) {
        var Movie;
        (function (Movie) {
            var PersonService;
            (function (PersonService) {
                PersonService.baseUrl = 'Movie/Person';
                var Methods;
                (function (Methods) {
                })(Methods = PersonService.Methods || (PersonService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    PersonService[x] = function (r, s, o) { return Q.serviceRequest(PersonService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = PersonService.baseUrl + '/' + x;
                });
            })(PersonService = Movie.PersonService || (Movie.PersonService = {}));
        })(Movie = Movie_63.Movie || (Movie_63.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_64) {
        var Movie;
        (function (Movie) {
            var ServiceForm = (function (_super) {
                __extends(ServiceForm, _super);
                function ServiceForm() {
                    _super.apply(this, arguments);
                }
                ServiceForm.formKey = 'Movie.Service';
                return ServiceForm;
            }(Serenity.PrefixedContext));
            Movie.ServiceForm = ServiceForm;
            [['Name', function () { return Serenity.StringEditor; }], ['Api', function () { return Serenity.StringEditor; }], ['Active', function () { return Serenity.BooleanEditor; }], ['IntervalRequest', function () { return Serenity.IntegerEditor; }], ['LastEvent', function () { return Serenity.StringEditor; }], ['LastEventPublishDateTime', function () { return Serenity.DateEditor; }], ['MaxRating', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ServiceForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_64.Movie || (Movie_64.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_65) {
        var Movie;
        (function (Movie) {
            var ServicePathForm = (function (_super) {
                __extends(ServicePathForm, _super);
                function ServicePathForm() {
                    _super.apply(this, arguments);
                }
                ServicePathForm.formKey = 'Movie.ServicePath';
                return ServicePathForm;
            }(Serenity.PrefixedContext));
            Movie.ServicePathForm = ServicePathForm;
            [['Path', function () { return Serenity.StringEditor; }], ['ServiceId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ServicePathForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_65.Movie || (Movie_65.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_66) {
        var Movie;
        (function (Movie) {
            var ServicePathRow;
            (function (ServicePathRow) {
                ServicePathRow.idProperty = 'ServicePathId';
                ServicePathRow.nameProperty = 'Path';
                ServicePathRow.localTextPrefix = 'Movie.ServicePath';
                ServicePathRow.lookupKey = 'Movie.ServicePath';
                function getLookup() {
                    return Q.getLookup('Movie.ServicePath');
                }
                ServicePathRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = ServicePathRow.Fields || (ServicePathRow.Fields = {}));
                ['ServicePathId', 'Path', 'ServiceId', 'ServiceName', 'ServiceApi', 'ServiceMaxRating'].forEach(function (x) { return Fields[x] = x; });
            })(ServicePathRow = Movie.ServicePathRow || (Movie.ServicePathRow = {}));
        })(Movie = Movie_66.Movie || (Movie_66.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_67) {
        var Movie;
        (function (Movie) {
            var ServicePathService;
            (function (ServicePathService) {
                ServicePathService.baseUrl = 'Movie/ServicePath';
                var Methods;
                (function (Methods) {
                })(Methods = ServicePathService.Methods || (ServicePathService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    ServicePathService[x] = function (r, s, o) { return Q.serviceRequest(ServicePathService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = ServicePathService.baseUrl + '/' + x;
                });
            })(ServicePathService = Movie.ServicePathService || (Movie.ServicePathService = {}));
        })(Movie = Movie_67.Movie || (Movie_67.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_68) {
        var Movie;
        (function (Movie) {
            var ServiceRatingForm = (function (_super) {
                __extends(ServiceRatingForm, _super);
                function ServiceRatingForm() {
                    _super.apply(this, arguments);
                }
                ServiceRatingForm.formKey = 'Movie.ServiceRating';
                return ServiceRatingForm;
            }(Serenity.PrefixedContext));
            Movie.ServiceRatingForm = ServiceRatingForm;
            [['Rating', function () { return Serenity.DecimalEditor; }], ['Id', function () { return Serenity.StringEditor; }], ['MovieId', function () { return Serenity.StringEditor; }], ['ServiceId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(ServiceRatingForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_68.Movie || (Movie_68.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_69) {
        var Movie;
        (function (Movie) {
            var ServiceRatingRow;
            (function (ServiceRatingRow) {
                ServiceRatingRow.idProperty = 'ServiceRatingId';
                ServiceRatingRow.localTextPrefix = 'Movie.ServiceRating';
                var Fields;
                (function (Fields) {
                })(Fields = ServiceRatingRow.Fields || (ServiceRatingRow.Fields = {}));
                ['ServiceRatingId', 'Rating', 'Id', 'MovieId', 'ServiceId', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget', 'ServiceName', 'ServiceApi', 'ServiceMaxRating'].forEach(function (x) { return Fields[x] = x; });
            })(ServiceRatingRow = Movie.ServiceRatingRow || (Movie.ServiceRatingRow = {}));
        })(Movie = Movie_69.Movie || (Movie_69.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_70) {
        var Movie;
        (function (Movie) {
            var ServiceRatingService;
            (function (ServiceRatingService) {
                ServiceRatingService.baseUrl = 'Movie/ServiceRating';
                var Methods;
                (function (Methods) {
                })(Methods = ServiceRatingService.Methods || (ServiceRatingService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    ServiceRatingService[x] = function (r, s, o) { return Q.serviceRequest(ServiceRatingService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = ServiceRatingService.baseUrl + '/' + x;
                });
            })(ServiceRatingService = Movie.ServiceRatingService || (Movie.ServiceRatingService = {}));
        })(Movie = Movie_70.Movie || (Movie_70.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_71) {
        var Movie;
        (function (Movie) {
            var ServiceRow;
            (function (ServiceRow) {
                ServiceRow.idProperty = 'ServiceId';
                ServiceRow.nameProperty = 'Name';
                ServiceRow.localTextPrefix = 'Movie.Service';
                ServiceRow.lookupKey = 'Movie.Service';
                function getLookup() {
                    return Q.getLookup('Movie.Service');
                }
                ServiceRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = ServiceRow.Fields || (ServiceRow.Fields = {}));
                ['ServiceId', 'Name', 'Api', 'Active', 'IntervalRequest', 'LastEvent', 'LastEventPublishDateTime', 'MaxRating', 'PathListPath', 'PathList'].forEach(function (x) { return Fields[x] = x; });
            })(ServiceRow = Movie.ServiceRow || (Movie.ServiceRow = {}));
        })(Movie = Movie_71.Movie || (Movie_71.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_72) {
        var Movie;
        (function (Movie) {
            var ServiceService;
            (function (ServiceService) {
                ServiceService.baseUrl = 'Movie/Service';
                var Methods;
                (function (Methods) {
                })(Methods = ServiceService.Methods || (ServiceService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    ServiceService[x] = function (r, s, o) { return Q.serviceRequest(ServiceService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = ServiceService.baseUrl + '/' + x;
                });
            })(ServiceService = Movie.ServiceService || (Movie.ServiceService = {}));
        })(Movie = Movie_72.Movie || (Movie_72.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_73) {
        var Movie;
        (function (Movie) {
            var TagForm = (function (_super) {
                __extends(TagForm, _super);
                function TagForm() {
                    _super.apply(this, arguments);
                }
                TagForm.formKey = 'Movie.Tag';
                return TagForm;
            }(Serenity.PrefixedContext));
            Movie.TagForm = TagForm;
            [['Name', function () { return Serenity.StringEditor; }]].forEach(function (x) { return Object.defineProperty(TagForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_73.Movie || (Movie_73.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_74) {
        var Movie;
        (function (Movie) {
            var TagRow;
            (function (TagRow) {
                TagRow.idProperty = 'TagId';
                TagRow.nameProperty = 'Name';
                TagRow.localTextPrefix = 'Movie.Tag';
                TagRow.lookupKey = 'Movie.Tag';
                function getLookup() {
                    return Q.getLookup('Movie.Tag');
                }
                TagRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = TagRow.Fields || (TagRow.Fields = {}));
                ['TagId', 'Name'].forEach(function (x) { return Fields[x] = x; });
            })(TagRow = Movie.TagRow || (Movie.TagRow = {}));
        })(Movie = Movie_74.Movie || (Movie_74.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_75) {
        var Movie;
        (function (Movie) {
            var TagService;
            (function (TagService) {
                TagService.baseUrl = 'Movie/Tag';
                var Methods;
                (function (Methods) {
                })(Methods = TagService.Methods || (TagService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    TagService[x] = function (r, s, o) { return Q.serviceRequest(TagService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = TagService.baseUrl + '/' + x;
                });
            })(TagService = Movie.TagService || (Movie.TagService = {}));
        })(Movie = Movie_75.Movie || (Movie_75.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_76) {
        var Movie;
        (function (Movie) {
            var VideoForm = (function (_super) {
                __extends(VideoForm, _super);
                function VideoForm() {
                    _super.apply(this, arguments);
                }
                VideoForm.formKey = 'Movie.Video';
                return VideoForm;
            }(Serenity.PrefixedContext));
            Movie.VideoForm = VideoForm;
            [['Path', function () { return Serenity.StringEditor; }], ['Player', function () { return Serenity.IntegerEditor; }], ['PathTorrent', function () { return Serenity.StringEditor; }], ['Name', function () { return Serenity.StringEditor; }], ['Translation', function () { return Serenity.IntegerEditor; }], ['Season', function () { return Serenity.IntegerEditor; }], ['Serie', function () { return Serenity.IntegerEditor; }], ['Storyline', function () { return Serenity.StringEditor; }], ['PlannePublishDate', function () { return Serenity.DateEditor; }], ['ActualPublishDateTime', function () { return Serenity.DateEditor; }], ['MovieId', function () { return Serenity.StringEditor; }], ['ServiceId', function () { return Serenity.IntegerEditor; }]].forEach(function (x) { return Object.defineProperty(VideoForm.prototype, x[0], { get: function () { return this.w(x[0], x[1]()); }, enumerable: true, configurable: true }); });
        })(Movie = Movie_76.Movie || (Movie_76.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_77) {
        var Movie;
        (function (Movie) {
            var VideoRow;
            (function (VideoRow) {
                VideoRow.idProperty = 'VideoId';
                VideoRow.nameProperty = 'Path';
                VideoRow.localTextPrefix = 'Movie.Video';
                VideoRow.lookupKey = 'Movie.Video';
                function getLookup() {
                    return Q.getLookup('Movie.Video');
                }
                VideoRow.getLookup = getLookup;
                var Fields;
                (function (Fields) {
                })(Fields = VideoRow.Fields || (VideoRow.Fields = {}));
                ['VideoId', 'Path', 'Player', 'PathTorrent', 'Name', 'Translation', 'Season', 'Serie', 'Storyline', 'PlannePublishDate', 'ActualPublishDateTime', 'MovieId', 'ServiceId', 'ServiceName'].forEach(function (x) { return Fields[x] = x; });
            })(VideoRow = Movie.VideoRow || (Movie.VideoRow = {}));
        })(Movie = Movie_77.Movie || (Movie_77.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie_78) {
        var Movie;
        (function (Movie) {
            var VideoService;
            (function (VideoService) {
                VideoService.baseUrl = 'Movie/Video';
                var Methods;
                (function (Methods) {
                })(Methods = VideoService.Methods || (VideoService.Methods = {}));
                ['Create', 'Update', 'Delete', 'Retrieve', 'List'].forEach(function (x) {
                    VideoService[x] = function (r, s, o) { return Q.serviceRequest(VideoService.baseUrl + '/' + x, r, s, o); };
                    Methods[x] = VideoService.baseUrl + '/' + x;
                });
            })(VideoService = Movie.VideoService || (Movie.VideoService = {}));
        })(Movie = Movie_78.Movie || (Movie_78.Movie = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var BasicProgressDialog = (function (_super) {
            __extends(BasicProgressDialog, _super);
            function BasicProgressDialog() {
                var _this = this;
                _super.call(this);
                this.byId('ProgressBar').progressbar({
                    max: 100,
                    value: 0,
                    change: function (e, v) {
                        _this.byId('ProgressLabel').text(_this.value + ' / ' + _this.max);
                    }
                });
            }
            Object.defineProperty(BasicProgressDialog.prototype, "max", {
                get: function () {
                    return this.byId('ProgressBar').progressbar().progressbar('option', 'max');
                },
                set: function (value) {
                    this.byId('ProgressBar').progressbar().progressbar('option', 'max', value);
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(BasicProgressDialog.prototype, "value", {
                get: function () {
                    return this.byId('ProgressBar').progressbar('value');
                },
                set: function (value) {
                    this.byId('ProgressBar').progressbar().progressbar('value', value);
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(BasicProgressDialog.prototype, "title", {
                get: function () {
                    return this.element.dialog().dialog('option', 'title');
                },
                set: function (value) {
                    this.element.dialog().dialog('option', 'title', value);
                },
                enumerable: true,
                configurable: true
            });
            BasicProgressDialog.prototype.getDialogOptions = function () {
                var _this = this;
                var opt = _super.prototype.getDialogOptions.call(this);
                opt.title = Q.text('Site.BasicProgressDialog.PleaseWait');
                opt.width = 600;
                opt.buttons = [{
                        text: Q.text('Dialogs.CancelButton'),
                        click: function () {
                            _this.cancelled = true;
                            _this.element.closest('.ui-dialog')
                                .find('.ui-dialog-buttonpane .ui-button')
                                .attr('disabled', 'disabled')
                                .css('opacity', '0.5');
                            _this.element.dialog('option', 'title', Q.trimToNull(_this.cancelTitle) ||
                                Q.text('Site.BasicProgressDialog.CancelTitle'));
                        }
                    }];
                return opt;
            };
            BasicProgressDialog.prototype.initDialog = function () {
                _super.prototype.initDialog.call(this);
                this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
            };
            BasicProgressDialog.prototype.getTemplate = function () {
                return ("<div class='s-DialogContent s-BasicProgressDialogContent'>" +
                    "<div id='~_StatusText' class='status-text' ></div>" +
                    "<div id='~_ProgressBar' class='progress-bar'>" +
                    "<div id='~_ProgressLabel' class='progress-label' ></div>" +
                    "</div>" +
                    "</div>");
            };
            return BasicProgressDialog;
        }(Serenity.TemplatedDialog));
        Movie.BasicProgressDialog = BasicProgressDialog;
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var BulkServiceAction = (function () {
                function BulkServiceAction() {
                }
                BulkServiceAction.prototype.createProgressDialog = function () {
                    this.progressDialog = new Movie.BasicProgressDialog();
                    this.progressDialog.dialogOpen();
                    this.progressDialog.max = this.keys.length;
                    this.progressDialog.value = 0;
                };
                BulkServiceAction.prototype.getConfirmationFormat = function () {
                    return Q.text('Site.BulkServiceAction.ConfirmationFormat');
                };
                BulkServiceAction.prototype.getConfirmationMessage = function (targetCount) {
                    return Q.format(this.getConfirmationFormat(), targetCount);
                };
                BulkServiceAction.prototype.confirm = function (targetCount, action) {
                    Q.confirm(this.getConfirmationMessage(targetCount), action);
                };
                BulkServiceAction.prototype.getNothingToProcessMessage = function () {
                    return Q.text('Site.BulkServiceAction.NothingToProcess');
                };
                BulkServiceAction.prototype.nothingToProcess = function () {
                    Q.notifyError(this.getNothingToProcessMessage());
                };
                BulkServiceAction.prototype.getParallelRequests = function () {
                    return 1;
                };
                BulkServiceAction.prototype.getBatchSize = function () {
                    return 1;
                };
                BulkServiceAction.prototype.startParallelExecution = function () {
                    this.createProgressDialog();
                    this.successCount = 0;
                    this.errorCount = 0;
                    this.pendingRequests = 0;
                    this.completedRequests = 0;
                    this.errorCount = 0;
                    this.errorByKey = {};
                    this.queue = this.keys.slice();
                    this.queueIndex = 0;
                    var parallelRequests = this.getParallelRequests();
                    while (parallelRequests-- > 0) {
                        this.executeNextBatch();
                    }
                };
                BulkServiceAction.prototype.serviceCallCleanup = function () {
                    this.pendingRequests--;
                    this.completedRequests++;
                    var title = Q.text((this.progressDialog.cancelled ?
                        'Site.BasicProgressDialog.CancelTitle' : 'Site.BasicProgressDialog.PleaseWait'));
                    title += ' (';
                    if (this.successCount > 0) {
                        title += Q.format(Q.text('Site.BulkServiceAction.SuccessCount'), this.successCount);
                    }
                    if (this.errorCount > 0) {
                        if (this.successCount > 0) {
                            title += ', ';
                        }
                        title += Q.format(Q.text('Site.BulkServiceAction.ErrorCount'), this.errorCount);
                    }
                    this.progressDialog.title = title + ')';
                    this.progressDialog.value = this.successCount + this.errorCount;
                    if (!this.progressDialog.cancelled && this.progressDialog.value < this.keys.length) {
                        this.executeNextBatch();
                    }
                    else if (this.pendingRequests === 0) {
                        this.progressDialog.dialogClose();
                        this.showResults();
                        if (this.done) {
                            this.done();
                            this.done = null;
                        }
                    }
                };
                BulkServiceAction.prototype.executeForBatch = function (batch) {
                };
                BulkServiceAction.prototype.executeNextBatch = function () {
                    var batchSize = this.getBatchSize();
                    var batch = [];
                    while (true) {
                        if (batch.length >= batchSize) {
                            break;
                        }
                        if (this.queueIndex >= this.queue.length) {
                            break;
                        }
                        batch.push(this.queue[this.queueIndex++]);
                    }
                    if (batch.length > 0) {
                        this.pendingRequests++;
                        this.executeForBatch(batch);
                    }
                };
                BulkServiceAction.prototype.getAllHadErrorsFormat = function () {
                    return Q.text('Site.BulkServiceAction.AllHadErrorsFormat');
                };
                BulkServiceAction.prototype.showAllHadErrors = function () {
                    Q.notifyError(Q.format(this.getAllHadErrorsFormat(), this.errorCount));
                };
                BulkServiceAction.prototype.getSomeHadErrorsFormat = function () {
                    return Q.text('Site.BulkServiceAction.SomeHadErrorsFormat');
                };
                BulkServiceAction.prototype.showSomeHadErrors = function () {
                    Q.notifyWarning(Q.format(this.getSomeHadErrorsFormat(), this.successCount, this.errorCount));
                };
                BulkServiceAction.prototype.getAllSuccessFormat = function () {
                    return Q.text('Site.BulkServiceAction.AllSuccessFormat');
                };
                BulkServiceAction.prototype.showAllSuccess = function () {
                    Q.notifySuccess(Q.format(this.getAllSuccessFormat(), this.successCount));
                };
                BulkServiceAction.prototype.showResults = function () {
                    if (this.errorCount === 0 && this.successCount === 0) {
                        this.nothingToProcess();
                        return;
                    }
                    if (this.errorCount > 0 && this.successCount === 0) {
                        this.showAllHadErrors();
                        return;
                    }
                    if (this.errorCount > 0) {
                        this.showSomeHadErrors();
                        return;
                    }
                    this.showAllSuccess();
                };
                BulkServiceAction.prototype.execute = function (keys) {
                    var _this = this;
                    this.keys = keys;
                    if (this.keys.length === 0) {
                        this.nothingToProcess();
                        return;
                    }
                    this.confirm(this.keys.length, function () { return _this.startParallelExecution(); });
                };
                BulkServiceAction.prototype.get_successCount = function () {
                    return this.successCount;
                };
                BulkServiceAction.prototype.set_successCount = function (value) {
                    this.successCount = value;
                };
                BulkServiceAction.prototype.get_errorCount = function () {
                    return this.errorCount;
                };
                BulkServiceAction.prototype.set_errorCount = function (value) {
                    this.errorCount = value;
                };
                return BulkServiceAction;
            }());
            Common.BulkServiceAction = BulkServiceAction;
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var DialogUtils;
        (function (DialogUtils) {
            function pendingChangesConfirmation(element, hasPendingChanges) {
                element.bind('dialogbeforeclose', function (e) {
                    if (!Serenity.WX.hasOriginalEvent(e) || !hasPendingChanges()) {
                        return;
                    }
                    e.preventDefault();
                    Q.confirm('You have pending changes. Save them?', function () { return element.find('div.save-and-close-button').click(); }, {
                        onNo: function () {
                            element.dialog().dialog('close');
                        }
                    });
                });
            }
            DialogUtils.pendingChangesConfirmation = pendingChangesConfirmation;
        })(DialogUtils = Movie.DialogUtils || (Movie.DialogUtils = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var ExcelExportHelper;
            (function (ExcelExportHelper) {
                function createToolButton(options) {
                    return {
                        hint: Q.coalesce(options.title, 'Excel'),
                        title: Q.coalesce(options.hint, ''),
                        cssClass: 'export-xlsx-button',
                        onClick: function () {
                            if (!options.onViewSubmit()) {
                                return;
                            }
                            var grid = options.grid;
                            var request = Q.deepClone(grid.getView().params);
                            request.Take = 0;
                            request.Skip = 0;
                            var sortBy = grid.getView().sortBy;
                            if (sortBy) {
                                request.Sort = sortBy;
                            }
                            request.IncludeColumns = [];
                            var columns = grid.getGrid().getColumns();
                            for (var _i = 0, columns_1 = columns; _i < columns_1.length; _i++) {
                                var column = columns_1[_i];
                                request.IncludeColumns.push(column.id || column.field);
                            }
                            Q.postToService({ service: options.service, request: request, target: '_blank' });
                        },
                        separator: options.separator
                    };
                }
                ExcelExportHelper.createToolButton = createToolButton;
            })(ExcelExportHelper = Common.ExcelExportHelper || (Common.ExcelExportHelper = {}));
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var LanguageList;
        (function (LanguageList) {
            function getValue() {
                var result = [];
                for (var _i = 0, _a = Movie.Administration.LanguageRow.getLookup().items; _i < _a.length; _i++) {
                    var k = _a[_i];
                    if (k.LanguageId !== 'en') {
                        result.push([k.Id.toString(), k.LanguageName]);
                    }
                }
                return result;
            }
            LanguageList.getValue = getValue;
        })(LanguageList = Movie.LanguageList || (Movie.LanguageList = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Common;
        (function (Common) {
            var ReportHelper;
            (function (ReportHelper) {
                function createToolButton(options) {
                    return {
                        title: Q.coalesce(options.title, 'Report'),
                        cssClass: Q.coalesce(options.cssClass, 'print-button'),
                        icon: options.icon,
                        onClick: function () {
                            Q.postToUrl({
                                url: '~/Report/' + (options.download ? 'Download' : 'Render'),
                                params: {
                                    key: options.reportKey,
                                    ext: Q.coalesce(options.extension, 'pdf'),
                                    opt: (options.getParams == null ? '' : $.toJSON(options.getParams()))
                                },
                                target: Q.coalesce(options.target, '_blank')
                            });
                        }
                    };
                }
                ReportHelper.createToolButton = createToolButton;
            })(ReportHelper = Common.ReportHelper || (Common.ReportHelper = {}));
        })(Common = Movie.Common || (Movie.Common = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleCheckEditor = (function (_super) {
                __extends(RoleCheckEditor, _super);
                function RoleCheckEditor(div) {
                    _super.call(this, div);
                }
                RoleCheckEditor.prototype.createToolbarExtensions = function () {
                    var _this = this;
                    _super.prototype.createToolbarExtensions.call(this);
                    Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                        _this.searchText = Select2.util.stripDiacritics(text || '').toUpperCase();
                        _this.view.setItems(_this.view.getItems(), true);
                    });
                };
                RoleCheckEditor.prototype.getButtons = function () {
                    return [];
                };
                RoleCheckEditor.prototype.getTreeItems = function () {
                    return Administration.RoleRow.getLookup().items.map(function (role) { return {
                        id: role.RoleId.toString(),
                        text: role.RoleName
                    }; });
                };
                RoleCheckEditor.prototype.onViewFilter = function (item) {
                    return _super.prototype.onViewFilter.call(this, item) &&
                        (Q.isEmptyOrNull(this.searchText) ||
                            Select2.util.stripDiacritics(item.text || '')
                                .toUpperCase().indexOf(this.searchText) >= 0);
                };
                RoleCheckEditor = __decorate([
                    Serenity.Decorators.registerEditor()
                ], RoleCheckEditor);
                return RoleCheckEditor;
            }(Serenity.CheckTreeEditor));
            Administration.RoleCheckEditor = RoleCheckEditor;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserRoleDialog = (function (_super) {
                __extends(UserRoleDialog, _super);
                function UserRoleDialog(opt) {
                    var _this = this;
                    _super.call(this, opt);
                    this.permissions = new Administration.RoleCheckEditor(this.byId('Roles'));
                    Administration.UserRoleService.List({
                        UserID: this.options.userID
                    }, function (response) {
                        _this.permissions.value = response.Entities.map(function (x) { return x.toString(); });
                    });
                }
                UserRoleDialog.prototype.getDialogOptions = function () {
                    var _this = this;
                    var opt = _super.prototype.getDialogOptions.call(this);
                    opt.buttons = [{
                            text: Q.text('Dialogs.OkButton'),
                            click: function () {
                                Q.serviceRequest('Administration/UserRole/Update', {
                                    UserID: _this.options.userID,
                                    Roles: _this.permissions.value.map(function (x) { return parseInt(x, 10); })
                                }, function (response) {
                                    _this.dialogClose();
                                    Q.notifySuccess(Q.text('Site.UserRoleDialog.SaveSuccess'));
                                });
                            }
                        }, {
                            text: Q.text('Dialogs.CancelButton'),
                            click: function () { return _this.dialogClose(); }
                        }];
                    opt.title = Q.format(Q.text('Site.UserRoleDialog.DialogTitle'), this.options.username);
                    return opt;
                };
                UserRoleDialog.prototype.getTemplate = function () {
                    return "<div id='~_Roles'></div>";
                };
                UserRoleDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], UserRoleDialog);
                return UserRoleDialog;
            }(Serenity.TemplatedDialog));
            Administration.UserRoleDialog = UserRoleDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var PermissionCheckEditor = (function (_super) {
                __extends(PermissionCheckEditor, _super);
                function PermissionCheckEditor(container, opt) {
                    var _this = this;
                    _super.call(this, container, opt);
                    this.rolePermissions = {};
                    var titleByKey = {};
                    var permissionKeys = this.getSortedGroupAndPermissionKeys(titleByKey);
                    var items = permissionKeys.map(function (key) { return {
                        Key: key,
                        ParentKey: _this.getParentKey(key),
                        Title: titleByKey[key],
                        GrantRevoke: null,
                        IsGroup: key.charAt(key.length - 1) === ':'
                    }; });
                    this.byParentKey = Q.toGrouping(items, function (x) { return x.ParentKey; });
                    this.setItems(items);
                }
                PermissionCheckEditor.prototype.getIdProperty = function () { return "Key"; };
                PermissionCheckEditor.prototype.getItemGrantRevokeClass = function (item, grant) {
                    if (!item.IsGroup) {
                        return ((item.GrantRevoke === grant) ? ' checked' : '');
                    }
                    var desc = this.getDescendants(item, true);
                    var granted = desc.filter(function (x) { return x.GrantRevoke === grant; });
                    if (!granted.length) {
                        return '';
                    }
                    if (desc.length === granted.length) {
                        return 'checked';
                    }
                    return 'checked partial';
                };
                PermissionCheckEditor.prototype.getItemEffectiveClass = function (item) {
                    var _this = this;
                    if (item.IsGroup) {
                        var desc = this.getDescendants(item, true);
                        var grantCount = Q.count(desc, function (x) { return x.GrantRevoke === true ||
                            (x.GrantRevoke == null && _this.rolePermissions[x.Key]); });
                        if (grantCount === desc.length || desc.length === 0) {
                            return 'allow';
                        }
                        if (grantCount === 0) {
                            return 'deny';
                        }
                        return 'partial';
                    }
                    var granted = item.GrantRevoke === true ||
                        (item.GrantRevoke == null && this.rolePermissions[item.Key]);
                    return (granted ? ' allow' : ' deny');
                };
                PermissionCheckEditor.prototype.getColumns = function () {
                    var _this = this;
                    var columns = [{
                            name: Q.text('Site.UserPermissionDialog.Permission'),
                            field: 'Title',
                            format: Serenity.SlickFormatting.treeToggle(function () { return _this.view; }, function (x) { return x.Key; }, function (ctx) {
                                var item = ctx.item;
                                var klass = _this.getItemEffectiveClass(item);
                                return '<span class="effective-permission ' + klass + '">' + Q.htmlEncode(ctx.value) + '</span>';
                            }),
                            width: 495,
                            sortable: false
                        }, {
                            name: Q.text('Site.UserPermissionDialog.Grant'), field: 'Grant',
                            format: function (ctx) {
                                var item1 = ctx.item;
                                var klass1 = _this.getItemGrantRevokeClass(item1, true);
                                return "<span class='check-box grant no-float " + klass1 + "'></span>";
                            },
                            width: 65,
                            sortable: false,
                            headerCssClass: 'align-center',
                            cssClass: 'align-center'
                        }];
                    if (this.options.showRevoke) {
                        columns.push({
                            name: Q.text('Site.UserPermissionDialog.Revoke'), field: 'Revoke',
                            format: function (ctx) {
                                var item2 = ctx.item;
                                var klass2 = _this.getItemGrantRevokeClass(item2, false);
                                return '<span class="check-box revoke no-float ' + klass2 + '"></span>';
                            },
                            width: 65,
                            sortable: false,
                            headerCssClass: 'align-center',
                            cssClass: 'align-center'
                        });
                    }
                    return columns;
                };
                PermissionCheckEditor.prototype.setItems = function (items) {
                    Serenity.SlickTreeHelper.setIndents(items, function (x) { return x.Key; }, function (x) { return x.ParentKey; }, false);
                    this.view.setItems(items, true);
                };
                PermissionCheckEditor.prototype.onViewSubmit = function () {
                    return false;
                };
                PermissionCheckEditor.prototype.onViewFilter = function (item) {
                    var _this = this;
                    if (!_super.prototype.onViewFilter.call(this, item)) {
                        return false;
                    }
                    if (!Serenity.SlickTreeHelper.filterById(item, this.view, function (x) { return x.ParentKey; }))
                        return false;
                    if (this.searchText) {
                        return this.matchContains(item) || item.IsGroup && Q.any(this.getDescendants(item, false), function (x) { return _this.matchContains(x); });
                    }
                    return true;
                };
                PermissionCheckEditor.prototype.matchContains = function (item) {
                    return Select2.util.stripDiacritics(item.Title || '').toLowerCase().indexOf(this.searchText) >= 0;
                };
                PermissionCheckEditor.prototype.getDescendants = function (item, excludeGroups) {
                    var result = [];
                    var stack = [item];
                    while (stack.length > 0) {
                        var i = stack.pop();
                        var children = this.byParentKey[i.Key];
                        if (!children)
                            continue;
                        for (var _i = 0, children_1 = children; _i < children_1.length; _i++) {
                            var child = children_1[_i];
                            if (!excludeGroups || !child.IsGroup) {
                                result.push(child);
                            }
                            stack.push(child);
                        }
                    }
                    return result;
                };
                PermissionCheckEditor.prototype.onClick = function (e, row, cell) {
                    _super.prototype.onClick.call(this, e, row, cell);
                    if (!e.isDefaultPrevented()) {
                        Serenity.SlickTreeHelper.toggleClick(e, row, cell, this.view, function (x) { return x.Key; });
                    }
                    if (e.isDefaultPrevented()) {
                        return;
                    }
                    var target = $(e.target);
                    var grant = target.hasClass('grant');
                    if (grant || target.hasClass('revoke')) {
                        e.preventDefault();
                        var item = this.itemAt(row);
                        var checkedOrPartial = target.hasClass('checked') || target.hasClass('partial');
                        if (checkedOrPartial) {
                            grant = null;
                        }
                        else {
                            grant = grant !== checkedOrPartial;
                        }
                        if (item.IsGroup) {
                            for (var _i = 0, _a = this.getDescendants(item, true); _i < _a.length; _i++) {
                                var d = _a[_i];
                                d.GrantRevoke = grant;
                            }
                        }
                        else
                            item.GrantRevoke = grant;
                        this.slickGrid.invalidate();
                    }
                };
                PermissionCheckEditor.prototype.getParentKey = function (key) {
                    if (key.charAt(key.length - 1) === ':') {
                        key = key.substr(0, key.length - 1);
                    }
                    var idx = key.lastIndexOf(':');
                    if (idx >= 0) {
                        return key.substr(0, idx + 1);
                    }
                    return null;
                };
                PermissionCheckEditor.prototype.getButtons = function () {
                    return [];
                };
                PermissionCheckEditor.prototype.createToolbarExtensions = function () {
                    var _this = this;
                    _super.prototype.createToolbarExtensions.call(this);
                    Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, text) {
                        _this.searchText = Select2.util.stripDiacritics(Q.trimToNull(text) || '').toLowerCase();
                        _this.view.setItems(_this.view.getItems(), true);
                    });
                };
                PermissionCheckEditor.prototype.getSortedGroupAndPermissionKeys = function (titleByKey) {
                    var keys = Q.getRemoteData('Administration.PermissionKeys').Entities;
                    var titleWithGroup = {};
                    for (var _i = 0, keys_1 = keys; _i < keys_1.length; _i++) {
                        var k = keys_1[_i];
                        var s = k;
                        if (!s) {
                            continue;
                        }
                        if (s.charAt(s.length - 1) == ':') {
                            s = s.substr(0, s.length - 1);
                            if (s.length === 0) {
                                continue;
                            }
                        }
                        if (titleByKey[s]) {
                            continue;
                        }
                        titleByKey[s] = Q.coalesce(Q.tryGetText('Permission.' + s), s);
                        var parts = s.split(':');
                        var group = '';
                        var groupTitle = '';
                        for (var i = 0; i < parts.length - 1; i++) {
                            group = group + parts[i] + ':';
                            var txt = Q.tryGetText('Permission.' + group);
                            if (txt == null) {
                                txt = parts[i];
                            }
                            titleByKey[group] = txt;
                            groupTitle = groupTitle + titleByKey[group] + ':';
                            titleWithGroup[group] = groupTitle;
                        }
                        titleWithGroup[s] = groupTitle + titleByKey[s];
                    }
                    keys = Object.keys(titleByKey);
                    keys = keys.sort(function (x, y) { return Q.turkishLocaleCompare(titleWithGroup[x], titleWithGroup[y]); });
                    return keys;
                };
                PermissionCheckEditor.prototype.get_value = function () {
                    var result = [];
                    for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                        var item = _a[_i];
                        if (item.GrantRevoke != null && item.Key.charAt(item.Key.length - 1) != ':') {
                            result.push({ PermissionKey: item.Key, Granted: item.GrantRevoke });
                        }
                    }
                    return result;
                };
                PermissionCheckEditor.prototype.set_value = function (value) {
                    for (var _i = 0, _a = this.view.getItems(); _i < _a.length; _i++) {
                        var item = _a[_i];
                        item.GrantRevoke = null;
                    }
                    if (value != null) {
                        for (var _b = 0, value_1 = value; _b < value_1.length; _b++) {
                            var row = value_1[_b];
                            var r = this.view.getItemById(row.PermissionKey);
                            if (r) {
                                r.GrantRevoke = Q.coalesce(row.Granted, true);
                            }
                        }
                    }
                    this.setItems(this.getItems());
                };
                PermissionCheckEditor.prototype.get_rolePermissions = function () {
                    return Object.keys(this.rolePermissions);
                };
                PermissionCheckEditor.prototype.set_rolePermissions = function (value) {
                    this.rolePermissions = {};
                    if (value) {
                        for (var _i = 0, value_2 = value; _i < value_2.length; _i++) {
                            var k = value_2[_i];
                            this.rolePermissions[k] = true;
                        }
                    }
                    this.setItems(this.getItems());
                };
                PermissionCheckEditor = __decorate([
                    Serenity.Decorators.registerEditor([Serenity.IGetEditValue, Serenity.ISetEditValue])
                ], PermissionCheckEditor);
                return PermissionCheckEditor;
            }(Serenity.DataGrid));
            Administration.PermissionCheckEditor = PermissionCheckEditor;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserPermissionDialog = (function (_super) {
                __extends(UserPermissionDialog, _super);
                function UserPermissionDialog(opt) {
                    var _this = this;
                    _super.call(this, opt);
                    this.permissions = new Administration.PermissionCheckEditor(this.byId('Permissions'), {
                        showRevoke: true
                    });
                    Administration.UserPermissionService.List({
                        UserID: this.options.userID,
                        Module: null,
                        Submodule: null
                    }, function (response) {
                        _this.permissions.set_value(response.Entities);
                    });
                    Administration.UserPermissionService.ListRolePermissions({
                        UserID: this.options.userID,
                        Module: null,
                        Submodule: null,
                    }, function (response) {
                        _this.permissions.set_rolePermissions(response.Entities);
                    });
                }
                UserPermissionDialog.prototype.getDialogOptions = function () {
                    var _this = this;
                    var opt = _super.prototype.getDialogOptions.call(this);
                    opt.buttons = [
                        {
                            text: Q.text('Dialogs.OkButton'),
                            click: function (e) {
                                Administration.UserPermissionService.Update({
                                    UserID: _this.options.userID,
                                    Permissions: _this.permissions.get_value(),
                                    Module: null,
                                    Submodule: null
                                }, function (response) {
                                    _this.dialogClose();
                                    window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.UserPermissionDialog.SaveSuccess')); }, 0);
                                });
                            }
                        }, {
                            text: Q.text('Dialogs.CancelButton'),
                            click: function () { return _this.dialogClose(); }
                        }];
                    opt.title = Q.format(Q.text('Site.UserPermissionDialog.DialogTitle'), this.options.username);
                    return opt;
                };
                UserPermissionDialog.prototype.getTemplate = function () {
                    return '<div id="~_Permissions"></div>';
                };
                UserPermissionDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], UserPermissionDialog);
                return UserPermissionDialog;
            }(Serenity.TemplatedDialog));
            Administration.UserPermissionDialog = UserPermissionDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserDialog = (function (_super) {
                __extends(UserDialog, _super);
                function UserDialog() {
                    var _this = this;
                    _super.call(this);
                    this.form = new Administration.UserForm(this.idPrefix);
                    this.form.Password.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.Password.value.length < 7)
                            return "Password must be at least 7 characters!";
                    });
                    this.form.PasswordConfirm.addValidationRule(this.uniqueName, function (e) {
                        if (_this.form.Password.value != _this.form.PasswordConfirm.value)
                            return "The passwords entered doesn't match!";
                    });
                }
                UserDialog.prototype.getFormKey = function () { return Administration.UserForm.formKey; };
                UserDialog.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
                UserDialog.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
                UserDialog.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
                UserDialog.prototype.getNameProperty = function () { return Administration.UserRow.nameProperty; };
                UserDialog.prototype.getService = function () { return Administration.UserService.baseUrl; };
                UserDialog.prototype.getToolbarButtons = function () {
                    var _this = this;
                    var buttons = _super.prototype.getToolbarButtons.call(this);
                    buttons.push({
                        title: Q.text('Site.UserDialog.EditRolesButton'),
                        cssClass: 'edit-roles-button',
                        icon: 'icon-people text-blue',
                        onClick: function () {
                            new Administration.UserRoleDialog({
                                userID: _this.entity.UserId,
                                username: _this.entity.Username
                            }).dialogOpen();
                        }
                    });
                    buttons.push({
                        title: Q.text('Site.UserDialog.EditPermissionsButton'),
                        cssClass: 'edit-permissions-button',
                        icon: 'icon-lock-open text-green',
                        onClick: function () {
                            new Administration.UserPermissionDialog({
                                userID: _this.entity.UserId,
                                username: _this.entity.Username
                            }).dialogOpen();
                        }
                    });
                    return buttons;
                };
                UserDialog.prototype.updateInterface = function () {
                    _super.prototype.updateInterface.call(this);
                    this.toolbar.findButton('edit-roles-button').toggleClass('disabled', this.isNewOrDeleted());
                    this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
                };
                UserDialog.prototype.afterLoadEntity = function () {
                    _super.prototype.afterLoadEntity.call(this);
                    // these fields are only required in new record mode
                    this.form.Password.element.toggleClass('required', this.isNew())
                        .closest('.field').find('sup').toggle(this.isNew());
                    this.form.PasswordConfirm.element.toggleClass('required', this.isNew())
                        .closest('.field').find('sup').toggle(this.isNew());
                };
                UserDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], UserDialog);
                return UserDialog;
            }(Serenity.EntityDialog));
            Administration.UserDialog = UserDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var UserGrid = (function (_super) {
                __extends(UserGrid, _super);
                function UserGrid(container) {
                    _super.call(this, container);
                }
                UserGrid.prototype.getColumnsKey = function () { return "Administration.User"; };
                UserGrid.prototype.getDialogType = function () { return Administration.UserDialog; };
                UserGrid.prototype.getIdProperty = function () { return Administration.UserRow.idProperty; };
                UserGrid.prototype.getIsActiveProperty = function () { return Administration.UserRow.isActiveProperty; };
                UserGrid.prototype.getLocalTextPrefix = function () { return Administration.UserRow.localTextPrefix; };
                UserGrid.prototype.getService = function () { return Administration.UserService.baseUrl; };
                UserGrid.prototype.getDefaultSortBy = function () {
                    return [Administration.UserRow.Fields.Username];
                };
                UserGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], UserGrid);
                return UserGrid;
            }(Serenity.EntityGrid));
            Administration.UserGrid = UserGrid;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Authorization;
        (function (Authorization) {
            Object.defineProperty(Authorization, 'userDefinition', {
                get: function () {
                    return Q.getRemoteData('UserData');
                }
            });
            function hasPermission(permissionKey) {
                var ud = Authorization.userDefinition;
                return ud.Username === 'admin' || !!ud.Permissions[permissionKey];
            }
            Authorization.hasPermission = hasPermission;
        })(Authorization = Movie.Authorization || (Movie.Authorization = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var TranslationGrid = (function (_super) {
                __extends(TranslationGrid, _super);
                function TranslationGrid(container) {
                    var _this = this;
                    _super.call(this, container);
                    this.element.on('keyup.' + this.uniqueName + ' change.' + this.uniqueName, 'input.custom-text', function (e) {
                        var value = Q.trimToNull($(e.target).val());
                        if (value === '') {
                            value = null;
                        }
                        _this.view.getItemById($(e.target).data('key')).CustomText = value;
                        _this.hasChanges = true;
                    });
                }
                TranslationGrid.prototype.getIdProperty = function () { return "Key"; };
                TranslationGrid.prototype.getLocalTextPrefix = function () { return "Administration.Translation"; };
                TranslationGrid.prototype.getService = function () { return Administration.TranslationService.baseUrl; };
                TranslationGrid.prototype.onClick = function (e, row, cell) {
                    var _this = this;
                    _super.prototype.onClick.call(this, e, row, cell);
                    if (e.isDefaultPrevented()) {
                        return;
                    }
                    var item = this.itemAt(row);
                    var done;
                    if ($(e.target).hasClass('source-text')) {
                        e.preventDefault();
                        done = function () {
                            item.CustomText = item.SourceText;
                            _this.view.updateItem(item.Key, item);
                            _this.hasChanges = true;
                        };
                        if (Q.isTrimmedEmpty(item.CustomText) ||
                            (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.SourceText))) {
                            done();
                            return;
                        }
                        Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                        return;
                    }
                    if ($(e.target).hasClass('target-text')) {
                        e.preventDefault();
                        done = function () {
                            item.CustomText = item.TargetText;
                            _this.view.updateItem(item.Key, item);
                            _this.hasChanges = true;
                        };
                        if (Q.isTrimmedEmpty(item.CustomText) ||
                            (Q.trimToEmpty(item.CustomText) === Q.trimToEmpty(item.TargetText))) {
                            done();
                            return;
                        }
                        Q.confirm(Q.text('Db.Administration.Translation.OverrideConfirmation'), done);
                        return;
                    }
                };
                TranslationGrid.prototype.getColumns = function () {
                    var columns = [];
                    columns.push({ field: 'Key', width: 300, sortable: false });
                    columns.push({
                        field: 'SourceText',
                        width: 300,
                        sortable: false,
                        format: function (ctx) {
                            return Q.outerHtml($('<a/>')
                                .addClass('source-text')
                                .text(ctx.value || ''));
                        }
                    });
                    columns.push({
                        field: 'CustomText',
                        width: 300,
                        sortable: false,
                        format: function (ctx) { return Q.outerHtml($('<input/>')
                            .addClass('custom-text')
                            .attr('value', ctx.value)
                            .attr('type', 'text')
                            .attr('data-key', ctx.item.Key)); }
                    });
                    columns.push({
                        field: 'TargetText',
                        width: 300,
                        sortable: false,
                        format: function (ctx) { return Q.outerHtml($('<a/>')
                            .addClass('target-text')
                            .text(ctx.value || '')); }
                    });
                    return columns;
                };
                TranslationGrid.prototype.createToolbarExtensions = function () {
                    var _this = this;
                    _super.prototype.createToolbarExtensions.call(this);
                    var opt = {
                        lookupKey: 'Administration.Language'
                    };
                    this.sourceLanguage = Serenity.Widget.create({
                        type: Serenity.LookupEditor,
                        element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                            Q.text('Db.Administration.Translation.SourceLanguage') + ' ---'); },
                        options: opt
                    });
                    this.sourceLanguage.changeSelect2(function (e) {
                        if (_this.hasChanges) {
                            _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                        }
                        else {
                            _this.refresh();
                        }
                    });
                    this.targetLanguage = Serenity.Widget.create({
                        type: Serenity.LookupEditor,
                        element: function (el) { return el.appendTo(_this.toolbar.element).attr('placeholder', '--- ' +
                            Q.text('Db.Administration.Translation.TargetLanguage') + ' ---'); },
                        options: opt
                    });
                    this.targetLanguage.changeSelect2(function (e) {
                        if (_this.hasChanges) {
                            _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); });
                        }
                        else {
                            _this.refresh();
                        }
                    });
                };
                TranslationGrid.prototype.saveChanges = function (language) {
                    var _this = this;
                    var translations = {};
                    for (var _i = 0, _a = this.getItems(); _i < _a.length; _i++) {
                        var item = _a[_i];
                        translations[item.Key] = item.CustomText;
                    }
                    return RSVP.resolve(Administration.TranslationService.Update({
                        TargetLanguageID: language,
                        Translations: translations
                    })).then(function () {
                        _this.hasChanges = false;
                        language = Q.trimToNull(language) || 'invariant';
                        Q.notifySuccess('User translations in "' + language +
                            '" language are saved to "user.texts.' +
                            language + '.json" ' + 'file under "~/App_Data/texts/"', '');
                    });
                };
                TranslationGrid.prototype.onViewSubmit = function () {
                    var request = this.view.params;
                    request.SourceLanguageID = this.sourceLanguage.value;
                    this.targetLanguageKey = this.targetLanguage.value || '';
                    request.TargetLanguageID = this.targetLanguageKey;
                    this.hasChanges = false;
                    return _super.prototype.onViewSubmit.call(this);
                };
                TranslationGrid.prototype.getButtons = function () {
                    var _this = this;
                    return [{
                            title: Q.text('Db.Administration.Translation.SaveChangesButton'),
                            onClick: function (e) { return _this.saveChanges(_this.targetLanguageKey).then(function () { return _this.refresh(); }); },
                            cssClass: 'apply-changes-button'
                        }];
                };
                TranslationGrid.prototype.createQuickSearchInput = function () {
                    var _this = this;
                    Serenity.GridUtils.addQuickSearchInputCustom(this.toolbar.element, function (field, searchText) {
                        _this.searchText = searchText;
                        _this.view.setItems(_this.view.getItems(), true);
                    });
                };
                TranslationGrid.prototype.onViewFilter = function (item) {
                    if (!_super.prototype.onViewFilter.call(this, item)) {
                        return false;
                    }
                    if (!this.searchText) {
                        return true;
                    }
                    var sd = Select2.util.stripDiacritics;
                    var searching = sd(this.searchText).toLowerCase();
                    function match(str) {
                        if (!str)
                            return false;
                        return str.toLowerCase().indexOf(searching) >= 0;
                    }
                    return Q.isEmptyOrNull(searching) || match(item.Key) || match(item.SourceText) ||
                        match(item.TargetText) || match(item.CustomText);
                };
                TranslationGrid.prototype.usePager = function () {
                    return false;
                };
                TranslationGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], TranslationGrid);
                return TranslationGrid;
            }(Serenity.EntityGrid));
            Administration.TranslationGrid = TranslationGrid;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RolePermissionDialog = (function (_super) {
                __extends(RolePermissionDialog, _super);
                function RolePermissionDialog(opt) {
                    var _this = this;
                    _super.call(this, opt);
                    this.permissions = new Administration.PermissionCheckEditor(this.byId('Permissions'), {
                        showRevoke: false
                    });
                    Administration.RolePermissionService.List({
                        RoleID: this.options.roleID,
                        Module: null,
                        Submodule: null
                    }, function (response) {
                        _this.permissions.set_value(response.Entities.map(function (x) { return ({ PermissionKey: x }); }));
                    });
                }
                RolePermissionDialog.prototype.getDialogOptions = function () {
                    var _this = this;
                    var opt = _super.prototype.getDialogOptions.call(this);
                    opt.buttons = [
                        {
                            text: Q.text('Dialogs.OkButton'),
                            click: function (e) {
                                Administration.RolePermissionService.Update({
                                    RoleID: _this.options.roleID,
                                    Permissions: _this.permissions.get_value().map(function (x) { return x.PermissionKey; }),
                                    Module: null,
                                    Submodule: null
                                }, function (response) {
                                    _this.dialogClose();
                                    window.setTimeout(function () { return Q.notifySuccess(Q.text('Site.RolePermissionDialog.SaveSuccess')); }, 0);
                                });
                            }
                        }, {
                            text: Q.text('Dialogs.CancelButton'),
                            click: function () { return _this.dialogClose(); }
                        }];
                    opt.title = Q.format(Q.text('Site.RolePermissionDialog.DialogTitle'), this.options.title);
                    return opt;
                };
                RolePermissionDialog.prototype.getTemplate = function () {
                    return '<div id="~_Permissions"></div>';
                };
                RolePermissionDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], RolePermissionDialog);
                return RolePermissionDialog;
            }(Serenity.TemplatedDialog));
            Administration.RolePermissionDialog = RolePermissionDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleDialog = (function (_super) {
                __extends(RoleDialog, _super);
                function RoleDialog() {
                    _super.apply(this, arguments);
                    this.form = new Administration.RoleForm(this.idPrefix);
                }
                RoleDialog.prototype.getFormKey = function () { return Administration.RoleForm.formKey; };
                RoleDialog.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
                RoleDialog.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
                RoleDialog.prototype.getNameProperty = function () { return Administration.RoleRow.nameProperty; };
                RoleDialog.prototype.getService = function () { return Administration.RoleService.baseUrl; };
                RoleDialog.prototype.getToolbarButtons = function () {
                    var _this = this;
                    var buttons = _super.prototype.getToolbarButtons.call(this);
                    buttons.push({
                        title: Q.text('Site.RolePermissionDialog.EditButton'),
                        cssClass: 'edit-permissions-button',
                        icon: 'icon-lock-open text-green',
                        onClick: function () {
                            new Administration.RolePermissionDialog({
                                roleID: _this.entity.RoleId,
                                title: _this.entity.RoleName
                            }).dialogOpen();
                        }
                    });
                    return buttons;
                };
                RoleDialog.prototype.updateInterface = function () {
                    _super.prototype.updateInterface.call(this);
                    this.toolbar.findButton("edit-permissions-button").toggleClass("disabled", this.isNewOrDeleted());
                };
                RoleDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], RoleDialog);
                return RoleDialog;
            }(Serenity.EntityDialog));
            Administration.RoleDialog = RoleDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var RoleGrid = (function (_super) {
                __extends(RoleGrid, _super);
                function RoleGrid(container) {
                    _super.call(this, container);
                }
                RoleGrid.prototype.getColumnsKey = function () { return "Administration.Role"; };
                RoleGrid.prototype.getDialogType = function () { return Administration.RoleDialog; };
                RoleGrid.prototype.getIdProperty = function () { return Administration.RoleRow.idProperty; };
                RoleGrid.prototype.getLocalTextPrefix = function () { return Administration.RoleRow.localTextPrefix; };
                RoleGrid.prototype.getService = function () { return Administration.RoleService.baseUrl; };
                RoleGrid.prototype.getDefaultSortBy = function () {
                    return [Administration.RoleRow.Fields.RoleName];
                };
                RoleGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], RoleGrid);
                return RoleGrid;
            }(Serenity.EntityGrid));
            Administration.RoleGrid = RoleGrid;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var LanguageDialog = (function (_super) {
                __extends(LanguageDialog, _super);
                function LanguageDialog() {
                    _super.apply(this, arguments);
                    this.form = new Administration.LanguageForm(this.idPrefix);
                }
                LanguageDialog.prototype.getFormKey = function () { return Administration.LanguageForm.formKey; };
                LanguageDialog.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
                LanguageDialog.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
                LanguageDialog.prototype.getNameProperty = function () { return Administration.LanguageRow.nameProperty; };
                LanguageDialog.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
                LanguageDialog = __decorate([
                    Serenity.Decorators.registerClass()
                ], LanguageDialog);
                return LanguageDialog;
            }(Serenity.EntityDialog));
            Administration.LanguageDialog = LanguageDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var LanguageGrid = (function (_super) {
                __extends(LanguageGrid, _super);
                function LanguageGrid(container) {
                    _super.call(this, container);
                }
                LanguageGrid.prototype.getColumnsKey = function () { return "Administration.Language"; };
                LanguageGrid.prototype.getDialogType = function () { return Administration.LanguageDialog; };
                LanguageGrid.prototype.getIdProperty = function () { return Administration.LanguageRow.idProperty; };
                LanguageGrid.prototype.getLocalTextPrefix = function () { return Administration.LanguageRow.localTextPrefix; };
                LanguageGrid.prototype.getService = function () { return Administration.LanguageService.baseUrl; };
                LanguageGrid.prototype.getDefaultSortBy = function () {
                    return [Administration.LanguageRow.Fields.LanguageName];
                };
                LanguageGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], LanguageGrid);
                return LanguageGrid;
            }(Serenity.EntityGrid));
            Administration.LanguageGrid = LanguageGrid;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseDialog = (function (_super) {
                __extends(DataBaseDialog, _super);
                function DataBaseDialog() {
                    _super.apply(this, arguments);
                    this.form = new Administration.DataBaseForm(this.idPrefix);
                }
                DataBaseDialog.prototype.getFormKey = function () { return Administration.DataBaseForm.formKey; };
                DataBaseDialog.prototype.getIdProperty = function () { return Administration.DataBaseRow.idProperty; };
                DataBaseDialog.prototype.getLocalTextPrefix = function () { return Administration.DataBaseRow.localTextPrefix; };
                DataBaseDialog.prototype.getNameProperty = function () { return Administration.DataBaseRow.nameProperty; };
                DataBaseDialog.prototype.getService = function () { return Administration.DataBaseService.baseUrl; };
                DataBaseDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], DataBaseDialog);
                return DataBaseDialog;
            }(Serenity.EntityDialog));
            Administration.DataBaseDialog = DataBaseDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseEditor = (function (_super) {
                __extends(DataBaseEditor, _super);
                function DataBaseEditor(container) {
                    _super.call(this, container);
                }
                DataBaseEditor.prototype.getColumnsKey = function () { return 'Administration.DataBase'; };
                DataBaseEditor.prototype.getDialogType = function () { return Administration.DataBaseEditorDialog; };
                DataBaseEditor.prototype.getLocalTextPrefix = function () { return Administration.DataBaseRow.localTextPrefix; };
                DataBaseEditor = __decorate([
                    Serenity.Decorators.registerClass()
                ], DataBaseEditor);
                return DataBaseEditor;
            }(Movie.Common.GridEditorBase));
            Administration.DataBaseEditor = DataBaseEditor;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseEditorDialog = (function (_super) {
                __extends(DataBaseEditorDialog, _super);
                function DataBaseEditorDialog() {
                    _super.apply(this, arguments);
                    this.form = new Administration.DataBaseForm(this.idPrefix);
                }
                DataBaseEditorDialog.prototype.getFormKey = function () { return Administration.DataBaseForm.formKey; };
                DataBaseEditorDialog.prototype.getLocalTextPrefix = function () { return Administration.DataBaseRow.localTextPrefix; };
                DataBaseEditorDialog.prototype.getNameProperty = function () { return Administration.DataBaseRow.nameProperty; };
                DataBaseEditorDialog = __decorate([
                    Serenity.Decorators.registerClass(),
                    Serenity.Decorators.responsive()
                ], DataBaseEditorDialog);
                return DataBaseEditorDialog;
            }(Movie.Common.GridEditorDialog));
            Administration.DataBaseEditorDialog = DataBaseEditorDialog;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
var Cinema;
(function (Cinema) {
    var Movie;
    (function (Movie) {
        var Administration;
        (function (Administration) {
            var DataBaseGrid = (function (_super) {
                __extends(DataBaseGrid, _super);
                function DataBaseGrid(container) {
                    _super.call(this, container);
                }
                DataBaseGrid.prototype.getColumnsKey = function () { return 'Administration.DataBase'; };
                DataBaseGrid.prototype.getDialogType = function () { return Administration.DataBaseDialog; };
                DataBaseGrid.prototype.getIdProperty = function () { return Administration.DataBaseRow.idProperty; };
                DataBaseGrid.prototype.getLocalTextPrefix = function () { return Administration.DataBaseRow.localTextPrefix; };
                DataBaseGrid.prototype.getService = function () { return Administration.DataBaseService.baseUrl; };
                DataBaseGrid = __decorate([
                    Serenity.Decorators.registerClass()
                ], DataBaseGrid);
                return DataBaseGrid;
            }(Serenity.EntityGrid));
            Administration.DataBaseGrid = DataBaseGrid;
        })(Administration = Movie.Administration || (Movie.Administration = {}));
    })(Movie = Cinema.Movie || (Cinema.Movie = {}));
})(Cinema || (Cinema = {}));
//# sourceMappingURL=Cinema.Movie.Web.js.map