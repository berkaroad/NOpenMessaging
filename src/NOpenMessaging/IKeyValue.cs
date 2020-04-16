using System.Collections.Generic;

namespace NOpenMessaging
{
    /**
     * The {@code KeyValue} class represents a persistent set of attributes, which supports method chaining.
     * <p>
     * A {@code KeyValue} object only allows {@code String} keys and can contain four primitive type as values: {@code int},
     * {@code long}, {@code double}, {@code String}.
     * <p>
     * The {@code KeyValue} is a replacement of {@code Properties}, with simpler interfaces and reasonable entry limits.
     * <p>
     * A {@code KeyValue} object may be used in concurrent scenarios, so the implementation of {@code KeyValue} should
     * consider concurrent related issues.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    public interface IKeyValue
    {

        /**
         * Inserts or replaces {@code boolean} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, bool value);

        /**
         * Inserts or replaces {@code short} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, short value);

        /**
         * Inserts or replaces {@code int} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, int value);

        /**
         * Inserts or replaces {@code long} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, long value);

        /**
         * Inserts or replaces {@code double} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, double value);

        /**
         * Inserts or replaces {@code String} value for the specified key.
         *
         * @param key the key to be placed into this {@code KeyValue} object
         * @param value the value corresponding to <tt>key</tt>
         */
        IKeyValue put(string key, string value);

        /**
         * Searches for the {@code boolean} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, false is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, boolean)
         */
        bool getBoolean(string key);

        /**
         * Searches for the {@code boolean} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, false is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, boolean)
         */
        bool getBoolean(string key, bool defaultValue);

        /**
         * Searches for the {@code short} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, zero is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, short)
         */
        short getShort(string key);

        /**
         * Searches for the {@code short} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, zero is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, short)
         */
        short getShort(string key, short defaultValue);

        /**
         * Searches for the {@code int} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, zero is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, int)
         */
        int getInt(string key);

        /**
         * Searches for the {@code int} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, the default value argument is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, int)
         */
        int getInt(string key, int defaultValue);

        /**
         * Searches for the {@code long} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, zero is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, long)
         */
        long getLong(string key);

        /**
         * Searches for the {@code long} property with the specified key in this {@code KeyValue} object. If the key is not
         * found in this property list, the default value argument is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, long)
         */
        long getLong(string key, long defaultValue);

        /**
         * Searches for the {@code double} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, zero is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, double)
         */
        double getDouble(string key);

        /**
         * Searches for the {@code double} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, the default value argument is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, double)
         */
        double getDouble(string key, double defaultValue);

        /**
         * Searches for the {@code String} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, {@code null} is returned.
         *
         * @param key the property key
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, String)
         */
        string getString(string key);

        /**
         * Searches for the {@code String} property with the specified key in this {@code KeyValue} object. If the key is
         * not found in this property list, the default value argument is returned.
         *
         * @param key the property key
         * @param defaultValue a default value
         * @return the value in this {@code KeyValue} object with the specified key value
         * @see #put(String, String)
         */
        string getString(string key, string defaultValue);

        /**
         * Returns a {@link Set} view of the keys contained in this {@code KeyValue} object.
         * <p>
         * The set is backed by the {@code KeyValue}, so changes to the set are reflected in the @code KeyValue}, and
         * vice-versa.
         *
         * @return the key set view of this {@code KeyValue} object.
         */
        ISet<string> keySet();

        /**
         * Tests if the specified {@code String} is a key in this {@code KeyValue}.
         *
         * @param key possible key
         * @return <code>true</code> if and only if the specified key is in this {@code KeyValue}, <code>false</code>
         * otherwise.
         */
        bool containsKey(string key);
    }
}