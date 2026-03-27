# PDF to Image

一个基于 .NET 8 WinForms 的 PDF 转图片小工具，支持批量转换、拖拽导入和两种输出目录模式。

## 功能特点

- 支持选择一个或多个 PDF 文件批量转换
- 支持将 PDF 文件直接拖拽到界面中
- 支持两种输出方式
  - 输出到与 PDF 同名的子目录
  - 输出到 PDF 所在的当前目录
- 显示转换进度和当前处理页数
- 使用 `PDFtoImage` / `PDFium` 渲染

## 界面说明

- `选择 PDF 文件`
  - 通过文件选择框导入一个或多个 PDF
- 拖拽区域
  - 可以直接把一个或多个 PDF 拖到面板中
- `输出位置`
  - `生成在与 PDF 同名的子目录中`
  - `生成在 PDF 当前目录下`
- `开始转换`
  - 按当前选择的输出模式开始批量转换

## 输出规则

假设原文件为 `D:\Docs\示例.pdf`

当选择 `生成在与 PDF 同名的子目录中` 时：

```text
D:\Docs\示例\示例.jpg
D:\Docs\示例\示例2.jpg
D:\Docs\示例\示例3.jpg
```

当选择 `生成在 PDF 当前目录下` 时：

```text
D:\Docs\示例.jpg
D:\Docs\示例2.jpg
D:\Docs\示例3.jpg
```

命名规则如下：

- 第 1 页：`文件名.jpg`
- 第 2 页开始：`文件名2.jpg`、`文件名3.jpg`……

## 运行环境

- Windows
- .NET 8 SDK

## 开发与运行

在项目目录执行：

```powershell
dotnet build "PDF to Image.sln"
dotnet run --project "PDF to Image.csproj"
```

也可以直接用 Visual Studio 打开：

[`PDF to Image.sln`](d:/github/PixPDF/PDF%20to%20Image.sln)

## 项目结构

- [`Program.cs`](d:/github/PixPDF/Program.cs)
  - 程序入口
- [`Form1.cs`](d:/github/PixPDF/Form1.cs)
  - 选择文件、拖拽、转换逻辑、进度更新
- [`Form1.Designer.cs`](d:/github/PixPDF/Form1.Designer.cs)
  - WinForms 界面布局
- [`PDF to Image.csproj`](d:/github/PixPDF/PDF%20to%20Image.csproj)
  - 项目配置与依赖

## 依赖

- [`PDFtoImage 5.2.0`](https://www.nuget.org/packages/PDFtoImage/)

## 说明

- 当前版本默认输出为 JPG
- 如果当前目录下已经存在同名图片，可能会被覆盖
