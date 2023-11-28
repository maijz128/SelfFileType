function Description()
    return
        '2DFan(二次元爱好者)是一个专注于提供日本游戏、动漫相关内容的门户站点';
end

function ExtensionName() return '.2dfan'; end

function Icon() return '2dfan.ico'; end

function Urls() return {'2dfan.org'}; end

function FileName(url)
    local name = "2dfan";
    name = url:gsub("https://2dfan.org/", "");
    name = name:gsub("/", ".");
    return name;
end


-- local url = 'https://2dfan.org/subjects/9435';
-- print(FileName(url))


