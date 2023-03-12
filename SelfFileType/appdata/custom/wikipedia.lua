function Description()
    return
        '维基百科，自由的百科全书';
end

function ExtensionName() return '.wikipedia'; end

function Icon() return 'wikipedia.ico'; end

function Urls() return {'wikipedia.org'}; end

function FileName(url)
    local name = "维基百科";
    return name;
end




local url = 'https://zh.wikipedia.org/';
print(FileName(url))

