class Searcher {
    public string text { get; private set; } = string.Empty;
    int pos = 0;

    public Searcher(string text) {
        this.text = text;
    }

    public int search_next(string search_term) {
        int search_term_offset = 0;

        while (pos < text.Length) {
            if (text[pos] == search_term[search_term_offset]) {
                search_term_offset++;
                if (search_term_offset == search_term.Length) {
                    int ret = pos - search_term_offset + 1;
                    pos = ret + 1;

                    return ret;
                }
            } else if (search_term_offset != 0) {
                pos -= search_term_offset - 1;
                search_term_offset = 0;
            } 
            pos++;
        };

        return -1;
    }

    public void reset() {
        pos = 0;
    }
}
