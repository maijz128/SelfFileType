function Description()
    return
        'MyAnimeList - Anime and Manga Database and Community';
end

function ExtensionName() return '.myanimelist'; end

function Icon() return 'myanimelist.ico'; end

function Urls() return {'myanimelist.net'}; end

function FileName(url)
    local name = " MyAnimeList";
    name = url:gsub("https://myanimelist.net/", "");
    name = name:gsub("/", ".");
    return name;
end


-- local url_model = 'https://myanimelist.net/anime/41512/Kutsujoku_2_The_Animation';
-- print(FileName(url_model))


